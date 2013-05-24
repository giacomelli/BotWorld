#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using DG.BotWorld.BotSdk;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.RendererSdk;
using DG.Framework.IO;
using System.Xml.Serialization;
using System.Reflection;
using HelperSharp;


#endregion

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// The world hosting.
	/// Everything related with environments, bots and abilities must ben access by this facade.
	/// </summary>
	public class World
	{
		#region Events
		/// <summary>
		/// Occurs when a bot assembly is saved.
		/// </summary>
		public event EventHandler<BotAssemblySavedEventArgs> BotAssemblySaved;

		/// <summary>
		/// Occurs when a environment assembly is saved.
		/// </summary>
		public event EventHandler<EnvironmentAssemblySavedEventArgs> EnvironmentAssemblySaved;

		/// <summary>
		/// Occurs when a environment starts to running.
		/// </summary>
		public event EventHandler<EnvironmentRunningEventArgs> EnvironmentRunning;

		/// <summary>
		/// Occurs when environment is updated.
		/// </summary>
		public event EventHandler<EnvironmentUpdatedEventArgs> EnvironmentUpdated;

		/// <summary>
		/// Occurs when environment ends to run.
		/// </summary>
		public event EventHandler<EnvironmentRanEventArgs> EnvironmentRan;

		/// <summary>
		/// Occurs when environment is aborted.
		/// </summary>
		public event EventHandler<EnvironmentAbortedEventArgs> EnvironmentAborted;

		/// <summary>
		/// Occurs when environment is in error state.
		/// </summary>
		public event EventHandler<EnvironmentErrorEventArgs> EnvironmentError;
		#endregion

		#region Fields
		private IEnvironment m_currentEnvironment;
		private string m_currentInstanceRootDir;
		private Dictionary<string, Thread> m_environmentsRunningThreads = new Dictionary<string, Thread>();
		#endregion

		#region Properties
		/// <summary>
		/// Gets the context.
		/// </summary>
		public IWorldContext Context
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the environments.
		/// </summary>
		public IList<IEnvironment> Environments
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the environments infos.
		/// </summary>
		/// <value>
		/// The environments infos.
		/// </value>
		private IList<EnvironmentInfo> EnvironmentsInfos
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the bots.
		/// </summary>
		public IList<IBot> Bots
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the bots infos.
		/// </summary>
		/// <value>
		/// The bots infos.
		/// </value>
		private IList<BotInfo> BotsInfos
		{
			get;
			set;
		}
		#endregion

		#region Methods

		#region Bots stuffs
		/// <summary>
		/// Gets the bot abilities by bot name.
		/// </summary>
		/// <param name="botName">Name of the bot.</param>
		/// <returns>The abilities.</returns>
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		public IBotAbility[] GetBotAbilitiesByBotName(string botName)
		{
			if (String.IsNullOrEmpty(botName))
			{
				return new IBotAbility[0];
			}

			var botsInfos = BotsInfos;

			var query = from bi in botsInfos
						where bi.Bot.Name.Equals(botName, StringComparison.OrdinalIgnoreCase)
						select bi.Abilities;

			return query.First().ToArray();
		}

		/// <summary>
		/// Gets the bot abilities.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <returns>The abilities.</returns>
		public IBotAbility[] GetBotAbilities(IBot bot)
		{
			return GetBotAbilitiesByBotName(bot.Name);
		}

		/// <summary>
		/// Gets the type of the bot ability interface.
		/// </summary>
		/// <param name="botAbility">The bot ability.</param>
		/// <returns>The ability type</returns>
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		public Type GetBotAbilityInterfaceType(IBotAbility botAbility)
		{
			var botAbilityType = botAbility.GetType();

			return botAbilityType.GetInterfaces().Where(t => t.GetInterfaces().Count(i => i.Equals(typeof(IBotAbility))) > 0).First();
		}

		/// <summary>
		/// Gets the bot ability interface.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="interfaceType">Type of the interface.</param>
		/// <returns></returns>
		public IBotAbility GetBotAbilityByInterfaceType(IBot bot, Type interfaceType)
		{
			return GetBotAbilitiesByBotName(bot.Name).Where(a => a.GetType().GetInterfaces().Count(i => i.Equals(interfaceType)) == 1).FirstOrDefault();
		}

		/// <summary>
		/// Gets the bot ability by interface type.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="interfaceType">Type of the interface.</param>
		/// <returns></returns>
		public IBotAbility GetBotAbilityByInterfaceType(IBot bot, string interfaceType)
		{
			return GetBotAbilitiesByBotName(bot.Name).Where(a => a.GetType().GetInterfaces().Count(i => i.FullName.Equals(interfaceType, StringComparison.OrdinalIgnoreCase)) == 1).FirstOrDefault();
		}

		/// <summary>
		/// Gets the bot by name.
		/// </summary>
		/// <param name="botName">Name of the bot.</param>
		/// <returns></returns>
		public IBot GetBotByName(string botName)
		{
			return Bots.Where(b => b.Name.Equals(botName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
		}

		/// <summary>
		/// Gets the environment by name.
		/// </summary>
		/// <param name="environmentName">Name of the environment.</param>
		/// <returns></returns>
		public IEnvironment GetEnvironmentByName(string environmentName)
		{
			return Environments.Where(e => e.Name.Equals(environmentName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
		}

		/// <summary>
		/// Saves the environment assembly.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns>True if saved, otherwise false.</returns>
		public bool SaveEnvironmentAssembly(string fileName)
		{
			if (WorldCourt.JudgeEnvironmentAssembly(fileName))
			{
				var assemblyFileName = Path.GetFileName(fileName);
				var destFile = Path.Combine(ConfigHelper.EnvironmentsSourceRootDir, assemblyFileName);

				File.Copy(fileName, destFile, true);

				InitializeInstance();

				var environment = GetEnvironmentByAssemblyFileName(destFile);

				OnEnvironmentAssemblySaved(new EnvironmentAssemblySavedEventArgs(environment));

				return true;
			}

			return false; 
		}

		/// <summary>
		/// Raises the <see cref="E:EnvironmentAssemblySaved"/> event.
		/// </summary>
		/// <param name="e">The <see cref="DG.BotWorld.Hosting.EnvironmentAssemblySavedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnvironmentAssemblySaved(EnvironmentAssemblySavedEventArgs e)
		{
			if (EnvironmentAssemblySaved != null)
			{
				EnvironmentAssemblySaved(this, e);
			}
		}

		private IEnvironment GetEnvironmentByAssemblyFileName(string assemblyFileName)
		{
			return GetObjectByAssemblyFileName<IEnvironment>(Environments, assemblyFileName);
		}

		/// <summary>
		/// Saves the bot assembly.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		public bool SaveBotAssembly(string fileName)
		{
			if(WorldCourt.JudgeBotAssembly(fileName))
			{
				var assemblyFileName = Path.GetFileName(fileName);
				var destFile = Path.Combine(ConfigHelper.BotsSourceRootDir, assemblyFileName);
				
				File.Copy(fileName, destFile, true);                

				InitializeInstance();

				var bot = GetBotByAssemblyFileName(destFile);
				OnBotAssemblySaved(new BotAssemblySavedEventArgs(bot));
				return true;
			}

			return false;            
		}

		/// <summary>
		/// Raises the <see cref="E:BotAssemblySaved"/> event.
		/// </summary>
		/// <param name="e">The <see cref="DG.BotWorld.Hosting.BotAssemblySavedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnBotAssemblySaved(BotAssemblySavedEventArgs e)
		{
			if(BotAssemblySaved != null)
			{
				BotAssemblySaved(this, e);
			}
		}

		private IBot GetBotByAssemblyFileName(string assemblyFileName)
		{        
			return GetObjectByAssemblyFileName<IBot>(Bots, assemblyFileName);
		}

		/// <summary>
		/// Deletes the bot.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <returns>True if deleted, otherwise false.</returns>
		public bool DeleteBot(IBot bot)
		{
			var botAssemblyPath = GetBotSourceAssemplyPath(bot);

			if (File.Exists(botAssemblyPath))
			{
				File.Delete(botAssemblyPath);
			}
			else
			{
				return false;
			}
			
			var botDir = GetBotSourceDirPath(bot);
			if (Directory.Exists(botDir))
			{
				Directory.Delete(botDir, true);
			}

			InitializeInstance();
			return true;
		}

		private static string GetBotSourceAssemplyPath(IBot bot)
		{
			return Path.Combine(ConfigHelper.BotsSourceRootDir, bot.GetType().Assembly.GetName().Name) + ".dll";
		}

		private static string GetBotSourceDirPath(IBot bot)
		{
			return Path.Combine(ConfigHelper.BotsSourceRootDir, bot.Name);
		}

		/// <summary>
		/// Saves the bot ability assembly.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		public bool SaveBotAbilityAssembly(IBot bot, string fileName)
		{
			if (WorldCourt.JudgeBotAbilityAssembly(fileName))
			{
				var assemblyFileName = Path.GetFileName(fileName);
				var destFile = Path.Combine(GetBotAbilitiesSourceDir(bot), assemblyFileName);

				CreateBotDirs(bot, ConfigHelper.BotsSourceRootDir);

				File.Copy(fileName, destFile, true);

				InitializeInstance();
				return true;
			}

			return false;
		}

		/// <summary>
		/// Deletes the bot ability.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="botAbility">The bot ability.</param>
		/// <returns></returns>
		public bool DeleteBotAbility(IBot bot, IBotAbility botAbility)
		{
			var botAssemblyPath = GetBotAbilitySourceAssemplyPath(bot, botAbility);

			if (File.Exists(botAssemblyPath))
			{
				File.Delete(botAssemblyPath);
				InitializeInstance();
				return true;
			}
			else
			{
				return false;
			}           
		}

		private static string GetBotAbilitySourceAssemplyPath(IBot bot, IBotAbility botAbility)
		{
			return Path.Combine(GetBotAbilitiesSourceDir(bot), botAbility.GetType().Assembly.GetName().Name) + ".dll";
		}

		private static void CreateBotDirs(IBot bot, string botsRootDir)
		{
			var botDir = Path.Combine(botsRootDir, bot.Name);

			if (!Directory.Exists(botDir))
			{
				Directory.CreateDirectory(botDir);
			}

			var abilitiesDir = Path.Combine(botDir, "Abilities");

			if (!Directory.Exists(abilitiesDir))
			{
				Directory.CreateDirectory(abilitiesDir);
			}

			var imagesDir = Path.Combine(botDir, "Images");

			if (!Directory.Exists(imagesDir))
			{
				Directory.CreateDirectory(imagesDir);
			}
		}

		private static void CreateEnvironmentDirs(IEnvironment environment, string environmentsRootDir)
		{
			var environmentDir = Path.Combine(environmentsRootDir, environment.Name);

			if (!Directory.Exists(environmentDir))
			{
				Directory.CreateDirectory(environmentDir);
			}

			var renderersDir = Path.Combine(environmentDir, "Renderers");

			if (!Directory.Exists(renderersDir))
			{
				Directory.CreateDirectory(renderersDir);
			}

			var imagesDir = Path.Combine(environmentDir, "Images");

			if (!Directory.Exists(imagesDir))
			{
				Directory.CreateDirectory(imagesDir);
			}
		}

		/// <summary>
		/// Gets the bots for environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <returns></returns>
		public IBot[] GetBotsForEnvironment(IEnvironment environment)
		{
			var neededAbilities = environment.GetNeededBotAbilities();
			var selecedBotsInfos = BotsInfos.ToList();

			foreach (var needed in neededAbilities)
			{
				var query = from bi in selecedBotsInfos
							where bi.Abilities.Count(a => a.GetType().GetInterface(needed.FullName) != null) > 0
							select bi;
				
				selecedBotsInfos = query.ToList();
			}

			return selecedBotsInfos.Select(bi => bi.Bot).ToArray();
		}        
		#endregion

		#region Initialize
		/// <summary>
		/// Initializes the instance.
		/// </summary>
		protected void InitializeInstance()
		{
			CreateNewWorldInstanceDir();
			
			var environmentsInfoManager = new EnvironmentsInfoManager();
			Compose(environmentsInfoManager, EnvironmentsInstanceDir);
			Environments = environmentsInfoManager.Environments.AsReadOnly();

			EnvironmentsInfos = new List<EnvironmentInfo>();
			foreach (IEnvironment e in Environments)
			{
				var environmentInfo = new EnvironmentInfo(e);
				CreateEnvironmentDirs(e, EnvironmentsInstanceDir);
				Compose(environmentInfo, GetEnvironmentRenderersInstanceDir(e));
				EnvironmentHelper.SaveAvatar(e, this);
				EnvironmentsInfos.Add(environmentInfo);
			}
			

			var botsInfoManager = new BotsInfoManager();
			Compose(botsInfoManager, BotsInstanceDir);
			Bots = botsInfoManager.Bots.AsReadOnly();

			BotsInfos = new List<BotInfo>();
			foreach (IBot b in Bots)
			{
				var botInfo = new BotInfo(b);
				CreateBotDirs(b, BotsInstanceDir);
				Compose(botInfo, GetBotAbilitiesInstanceDir(b));                
				BotHelper.SaveAvatar(b, this);

				BotsInfos.Add(botInfo);
			}
			
			Context = new WorldContext();
		}

		/// <summary>
		/// Initializes the environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public void InitializeEnvironment(IEnvironment environment)
		{
			// Initialize the environment.
			var ctx = new WorldContext();
			Context = ctx;
			environment.Initialize(Context);
		}
		#endregion

		#region Run and update
		/// <summary>
		/// Runs the environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="bots">The bots.</param>
		public void RunEnvironment(IEnvironment environment, params IBot[] bots)
		{
			RunEnvironment(new object[2] { environment, bots });
		}

		/// <summary>
		/// Runs the environment async.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="bots">The bots.</param>
		public void RunEnvironmentAsync(IEnvironment environment, params IBot[] bots)
		{
			lock (this)
			{
				var key = environment.Name;
				AbortEnvironment(environment);

				var t = new Thread(new ParameterizedThreadStart(RunEnvironment));
				m_environmentsRunningThreads.Add(key, t);
				t.Start(new object[2] { environment, bots });
			}
		}

		/// <summary>
		/// Aborts the environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public void AbortEnvironment(IEnvironment environment)
		{
			lock (this)
			{
				var key = environment.Name;

				if (m_environmentsRunningThreads.ContainsKey(key))
				{
					var t = m_environmentsRunningThreads[key];
					m_environmentsRunningThreads.Remove(key);
					t.Abort();
					OnEnvironmentAborted(new EnvironmentAbortedEventArgs(environment));
				}
			}
		}

		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		private void RunEnvironment(object args)
		{
			var argsArray = (object[])args;
			var environment = (IEnvironment)argsArray[0];
			var bots = (IBot[])argsArray[1];

			try
			{
				OnEnvironmentRunning(new EnvironmentRunningEventArgs(environment, new List<IBot>(bots)));

				var ctx = new WorldContext();

				// Select the bots.
				ctx.ClearBots();

				foreach (IBot b in bots)
				{
					var query = from bi in BotsInfos
								where bi.Bot.GetType().Equals(b.GetType())
								select bi.Abilities;

					ctx.AddBot(b, query.First().ToArray());
				}

				// Initialize the round.
				environment.InitializeRound(ctx);
				Context = ctx;

				environment.State = EnvironmentState.Running;

				while (ctx.Cycle < environment.MaxUpdateCycles && environment.State == EnvironmentState.Running)
				{
					UpdateEnvironment(environment);
				}

				if (ctx.Cycle >= environment.MaxUpdateCycles)
				{
					environment.State = EnvironmentState.Aborted;
					OnEnvironmentAborted(new EnvironmentAbortedEventArgs(environment));
					return;
				}

				OnEnvironmentRan(new EnvironmentRanEventArgs(environment, new List<IBot>(bots), ctx.Cycle));
			}
			catch (Exception ex)
			{
				OnEnvironmentError(new EnvironmentErrorEventArgs(environment, ex));
			}
			finally
			{
				m_environmentsRunningThreads.Remove(environment.Name);
			}
		}

		/// <summary>
		/// Raises the <see cref="E:EnvironmentRunning"/> event.
		/// </summary>
		/// <param name="e">The <see cref="DG.BotWorld.Hosting.EnvironmentRunningEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnvironmentRunning(EnvironmentRunningEventArgs e)
		{
			if (EnvironmentRunning != null)
			{
				EnvironmentRunning(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="E:EnvironmentRan"/> event.
		/// </summary>
		/// <param name="e">The <see cref="DG.BotWorld.Hosting.EnvironmentRanEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnvironmentRan(EnvironmentRanEventArgs e)
		{
			if (EnvironmentRan != null)
			{
				EnvironmentRan(this, e);
			}
		}


		/// <summary>
		/// Renders the environment to image.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <returns></returns>
		public Image RenderEnvironmentToImage(IEnvironment environment)
		{
			try
			{
				var query = from ei in EnvironmentsInfos
							where ei.Environment.GetType().Equals(environment.GetType())
							select ei.Renderers.FirstOrDefault();

				var renderer = (IEnvironmentImageRenderer) query.FirstOrDefault();

				if(renderer != null)
				{
					renderer.Render(environment);
					ValidateRenderImage(renderer.OutputImage);
					return renderer.OutputImage;
				}

				return null;
			}
			catch(Exception ex) {
				var msg = String.Format (CultureInfo.InvariantCulture, "Error trying to renderize the environemnt '{0}'.", environment.Name);
				throw new WorldException(msg, ex);
			}
		}

		private void ValidateRenderImage (Image outputImage)
		{
			if (outputImage != null && (outputImage.Size.Width <= 0 || outputImage.Size.Height <= 0)) {
				throw new WorldException ("Render OutputImage should have width and height greater than zero.");
			}
		}


		private void UpdateEnvironment(IEnvironment environment)
		{
			((WorldContext)Context).Cycle++;

			var waitHandles = new WaitHandle[]
			{
				new AutoResetEvent(false)
			};

			m_currentEnvironment = environment;

			var updateThread = new Thread(new ParameterizedThreadStart(UpdateEnvironmentThread), 500);

			try
			{
				updateThread.Start(waitHandles[0]);
				
				if (!WaitHandle.WaitAll(waitHandles, environment.UpdateTimeout))
				{
					updateThread.Abort();
					throw new InvalidOperationException("Ambiente excedeu o tempo limite para atualização.");
				}
			}
			catch (OutOfMemoryException)
			{
				throw new InvalidOperationException("Ambiente excedeu o limite de memória.");
			}
			catch (StackOverflowException)
			{
				throw new InvalidOperationException("Ambiente excedeu o limite de memória.");
			}

			OnEnvironmentUpdated(new EnvironmentUpdatedEventArgs(environment, Context.Cycle));
		}

		private void UpdateEnvironmentThread(object state)
		{
			AutoResetEvent autoReset = (AutoResetEvent)state;

			m_currentEnvironment.Update(Context);

			autoReset.Set();
		}
		#endregion

		#region MEF
		private static string GetUniqueDirName()
		{
			return DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
		}

		private void CreateNewWorldInstanceDir()
		{
			var dir = GetUniqueDirName();

			m_currentInstanceRootDir = Path.Combine(ConfigHelper.WorldInstancesRootDir, dir);

			Directory.CreateDirectory(m_currentInstanceRootDir);
			FileHelper.CopyFiles(ConfigHelper.WorldSourceRootDir, m_currentInstanceRootDir, true, true);

			EnvironmentsInstanceDir = Path.Combine(m_currentInstanceRootDir, "Environments");
			BotsInstanceDir = Path.Combine(m_currentInstanceRootDir, "Bots");
		}

		internal string EnvironmentsInstanceDir
		{
			get;
			private set;
		}

		internal string BotsInstanceDir
		{
			get;
			private set;
		}

		private string GetBotInstanceDir(IBot bot)
		{
			return Path.Combine(BotsInstanceDir, bot.Name);
		}

		private static string GetBotAbilitiesSourceDir(IBot bot)
		{
			return Path.Combine(ConfigHelper.BotsSourceRootDir, bot.Name, "Abilities");
		}

		private string GetBotAbilitiesInstanceDir(IBot bot)
		{
			return Path.Combine(GetBotInstanceDir(bot), "Abilities");
		}

		private string GetEnvironmentRenderersInstanceDir(IEnvironment environment)
		{
			return Path.Combine(GetEnvironmentInstanceDir(environment), "Renderers");
		}

		private string GetEnvironmentInstanceDir(IEnvironment environment)
		{
			return Path.Combine(EnvironmentsInstanceDir, environment.Name.Replace(" ", String.Empty));
		}

		/// <summary>
		/// Creates the environment in judgment directory.
		/// </summary>
		/// <returns></returns>
		public string CreateEnvironmentInJudgmentDir()
		{
			var dir = Path.Combine(EnvironmentsInstanceDir, "InJudgment", GetUniqueDirName());
			Directory.CreateDirectory(dir);

			return dir;
		}

		/// <summary>
		/// Creates the bot abilities in judgment directory.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <returns></returns>
		public string CreateBotAbilitiesInJudgmentDir(IBot bot)
		{
			var dir = Path.Combine(GetBotAbilitiesInstanceDir(bot), "InJudgment", GetUniqueDirName());
			Directory.CreateDirectory(dir);

			return dir;
		}

		/// <summary>
		/// Creates the bot in judgment directory.
		/// </summary>
		/// <returns></returns>
		public string CreateBotInJudgmentDir()
		{
			var dir = Path.Combine(BotsInstanceDir, "InJudgment", GetUniqueDirName());
			Directory.CreateDirectory(dir);

			return dir;
		}

		private static void Compose(object part, string dir)
		{
			try
			{
				var catalog = new DirectoryCatalog(dir);
				using (var container = new CompositionContainer(catalog))
				{
					CompositionBatch batch = new CompositionBatch();
					batch.AddPart(part);

					container.Compose(batch);
				}
			}
			catch(ReflectionTypeLoadException ex) {
				throw new WorldException (
					"Error loading environment assembly: '{0}'.".With (ex.LoaderExceptions[0].Message), ex);
			}
		}
		#endregion

		#region Utils
		private static TObject GetObjectByAssemblyFileName<TObject>(IList<TObject> objects, string assemblyFileName)
		{
			string onlyFileName = Path.GetFileName(assemblyFileName);

			var query = from b in objects
						where Path.GetFileName(b.GetType().Assembly.Location).Equals(onlyFileName, StringComparison.OrdinalIgnoreCase)
						select b;

			return query.First();
		}
		#endregion

		#region Events launchers
		/// <summary>
		/// Raises the <see cref="E:EnvironmentUpdated"/> event.
		/// </summary>
		/// <param name="e">The <see cref="DG.BotWorld.Hosting.EnvironmentUpdatedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnvironmentUpdated(EnvironmentUpdatedEventArgs e)
		{
			if (EnvironmentUpdated != null)
			{
				EnvironmentUpdated(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="E:EnvironmentAborted"/> event.
		/// </summary>
		/// <param name="e">The <see cref="DG.BotWorld.Hosting.EnvironmentAbortedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnvironmentAborted(EnvironmentAbortedEventArgs e)
		{
			if (EnvironmentAborted != null)
			{
				EnvironmentAborted(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="E:EnvironmentError"/> event.
		/// </summary>
		/// <param name="e">The <see cref="DG.BotWorld.Hosting.EnvironmentErrorEventArgs"/> instance containing the event data.</param>
		protected virtual void OnEnvironmentError(EnvironmentErrorEventArgs e)
		{
			if (EnvironmentError!= null)
			{
				EnvironmentError(this, e);
			}
		}
		#endregion

		#endregion
	}
}
