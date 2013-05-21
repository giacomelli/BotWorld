using NUnit.Framework;
using System;
using Rhino.Mocks;
using TestSharp;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting.UnitTests
{
	[TestFixture()]
	public class EnvironmentHelperTest
	{
		[Test()]
		public void SaveAvatar_NullEnvironment_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("environment"), () => {
				EnvironmentHelper.SaveAvatar ((IEnvironment) null, new World ());
			});
		}

		[Test()]
		public void SaveAvatar_NullWorld_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("world"), () => {
				EnvironmentHelper.SaveAvatar (MockRepository.GenerateMock<IEnvironment>(), null);
			});
		}

		[Test()]
		public void SaveAvatar_AvatarUnavailable_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Is impossible save the avatar because the environemnt has no UIInformation about it.",  "environment"), () => {
				EnvironmentHelper.SaveAvatar (MockRepository.GenerateMock<IEnvironment>(), new World ());
			});
		}
	}
}

