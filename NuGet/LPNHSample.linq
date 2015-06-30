<Query Kind="Program">
  <NuGetReference>LINQPad.NHibernate.FormatSQL</NuGetReference>
  <NuGetReference>LINQPad.NHibernate.FormatSQL.Sample</NuGetReference>
  <Namespace>LINQPad.NHibernate.FormatSQL</Namespace>
</Query>

void Main()
{
	// SQLite needs a system environment variable to be set in order to work correctly in LINQPad (otherwise it can't find SQLite.Interop.dll)
	// The best way to do this is to download the NuGet package from here: https://www.nuget.org/packages/System.Data.SQLite.Core/1.0.97, extract it 
	// (remember, .nupkg files are just zip files) and point to the relevant framework directory like this:
	// [NOTE: If you aren't using SQLite then you don't need to set this environment variable.]
	var path = @"C:\Users\Tom\Downloads\system.data.sqlite.core.1.0.97\build\net45";
	System.Environment.SetEnvironmentVariable("PreLoadSQLite_BaseDirectory", path);

	using (var nHibernateSqlOutputRedirector = new NHibernateSqlOutputRedirector())
	{
		var authors = LINQPad.NHibernate.FormatSQL.Sample.Main.Get();
		authors.Dump();
	}
}