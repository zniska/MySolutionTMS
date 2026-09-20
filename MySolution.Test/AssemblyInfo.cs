using NUnit.Framework;
using log4net;

[assembly: LevelOfParallelism(5)]

[assembly: log4net.Config.XmlConfigurator(
    ConfigFile = "log4net.config",
    Watch = true
)]