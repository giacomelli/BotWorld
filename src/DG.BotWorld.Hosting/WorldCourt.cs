#region Usings
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using DG.BotWorld.BotSdk;
using DG.BotWorld.EnvironmentSdk;
#endregion

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Represents a court to judge the environments, bots e others components of the world.
	/// </summary>
	public static class WorldCourt
	{
		#region Environment
		/// <summary>
		/// Judges the environment assembly.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns>True if assembly has no penalties, otherwise false.</returns>
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public static bool JudgeEnvironmentAssembly(string fileName)
		{
			Assembly environmentAssembly;

			try
			{
				environmentAssembly = Assembly.LoadFile(fileName);
			}
			catch
			{
				return false;
			}

			if (environmentAssembly == null)
			{
				return false;
			}

			if (!CheckReferencedAssemblies(environmentAssembly))
			{
				return false;
			}

			if (!CheckIEnvironmentInterfaceImplementation(environmentAssembly))
			{
				return false;
			}

			if (!CheckExportAttribute(GetEnvironmentClass(environmentAssembly)))
			{
				return false;
			}

			return true;
		}
	
		private static bool CheckIEnvironmentInterfaceImplementation(Assembly inJudgmentAssembly)
		{
			var environmentInterfaceType = typeof(IEnvironment);

			var query = from tp in inJudgmentAssembly.GetTypes()
						where tp.GetInterfaces().Count(i => i.Equals(environmentInterfaceType)) > 0
						select tp;

			return query.Count() > 0;
		}

		private static Type GetEnvironmentClass(Assembly inJudgmentAssembly)
		{
			var environmentInterfaceType = typeof(IEnvironment);

			var query = from tp in inJudgmentAssembly.GetTypes()
						where tp.GetInterfaces().Count(i => i.Equals(environmentInterfaceType)) > 0
						select tp;

			return query.FirstOrDefault();
		}
		#endregion

		#region Bot
		/// <summary>
		/// Judges the bot assembly.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns>True if assembly has no penalties, otherwise false.</returns>
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public static bool JudgeBotAssembly(string fileName)
		{            
			Assembly botAssembly;

			try
			{
				botAssembly = Assembly.LoadFile(fileName);
			}
			catch
			{
				return false;
			}

			if (botAssembly == null)
			{
				return false;
			}

			if (!CheckReferencedAssemblies(botAssembly))
			{
				return false;                
			}

			if (!CheckIBotInterfaceImplementation(botAssembly))
			{
				return false;
			}

			if (!CheckExportAttribute(GetBotClass(botAssembly)))
			{
				return false;
			}

			return true;            
		}

		private static bool CheckIBotInterfaceImplementation(Assembly inJudgmentAssembly)
		{
			var botInterfaceType = typeof(IBot);

			var query = from tp in inJudgmentAssembly.GetTypes()
						where tp.GetInterfaces().Count(i => i.Equals(botInterfaceType)) > 0
						select tp;

			return query.Count() > 0;
		}

		private static Type GetBotClass(Assembly inJudgmentAssembly)
		{
			var botInterfaceType = typeof(IBot);

			var query = from tp in inJudgmentAssembly.GetTypes()
						where tp.GetInterfaces().Count(i => i.Equals(botInterfaceType)) > 0
						select tp;

			return query.FirstOrDefault();
		}
		#endregion

		#region Bot ability
		/// <summary>
		/// Judges the bot ability assembly.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns>True if assembly has no penalties, otherwise false.</returns>
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public static bool JudgeBotAbilityAssembly(string fileName)
		{
			Assembly botAbilityAssembly;

			try
			{
				botAbilityAssembly = Assembly.LoadFile(fileName);
			}
			catch
			{
				return false;
			}

			if (botAbilityAssembly == null)
			{
				return false;
			}

			if (!CheckReferencedAssemblies(botAbilityAssembly))
			{
				return false;
			}

			if (!CheckIBotAbilityInterfaceImplementation(botAbilityAssembly))
			{
				return false;
			}

			if (!CheckExportAttribute(GetBotAbilityClass(botAbilityAssembly)))
			{
				return false;
			}

			return true;
		}

		private static bool CheckIBotAbilityInterfaceImplementation(Assembly inJudgmentAssembly)
		{
			var botAbilityInterfaceType = typeof(IBotAbility);

			var query = from tp in inJudgmentAssembly.GetTypes()
						where tp.GetInterfaces().Count(t => t.GetInterfaces().Count(i => i.Equals(botAbilityInterfaceType)) > 0) > 0
						select tp;

			return query.Count() == 1;
		}

		private static Type GetBotAbilityClass(Assembly inJudgmentAssembly)
		{
			var botAbilityInterfaceType = typeof(IBotAbility);

			var query = from tp in inJudgmentAssembly.GetTypes()
						where tp.GetInterfaces().Count(t => t.GetInterfaces().Count(i => i.Equals(botAbilityInterfaceType)) > 0) > 0
						select tp;

			return query.FirstOrDefault();
		}
		#endregion

		#region Utils
		private static bool CheckExportAttribute(Type toCheckClass)
		{
			return toCheckClass.GetCustomAttributes(typeof(System.ComponentModel.Composition.ExportAttribute), true).Count() == 1;             
		}

		private static bool CheckReferencedAssemblies(Assembly inJudgmentAssembly)
		{
			var referencedAssemblies = inJudgmentAssembly.GetReferencedAssemblies();

			var query = from ra in referencedAssemblies
						where ra.Name.Equals("System.Net", StringComparison.OrdinalIgnoreCase) || ra.FullName.Equals("System.IO")
						select ra;

			if (query.Count() > 0)
			{
				return false;
			}

			query = from ra in referencedAssemblies
					where ra.Name.Equals("DG.BotWorld.BotSdk", StringComparison.OrdinalIgnoreCase)
					select ra;

			return query.Count() == 1;
		}
		#endregion        
	}
}
