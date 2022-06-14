using NUnit.Framework;

namespace Helpers.Drivers
{
    public class SauceTestContext
    {
        private const string UserName = "sudhan_s";
        private const string AccessKey = "11d082dd-d931-4291-9a46-6e506ed1d01d";
        private string Name;
        private string Build;

        public SauceTestContext()
        {
            this.Name = TestContext.CurrentContext.Test.Name;
            this.Build = $"{TestContext.CurrentContext.Test.FullName}_{TestContext.CurrentContext.Test.MethodName}";
        }

        public Dictionary<string, string> SauceOptions()
        {
            return new Dictionary<string, string>
            {
                ["username"] = UserName,
                ["accessKey"] = AccessKey,
                ["name"] = Name,
                ["build"] = Build
            };
        }
    }
}
