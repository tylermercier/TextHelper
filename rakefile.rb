PROJECT = "TextHelper"
BUILD_CONFIG = "Debug"
MSBUILD_PATH = "C:/Windows/Microsoft.NET/Framework/v4.0.30319/msbuild.exe"
NUNIT_PATH = "packages/NUnit.2.5.9.10348/tools/nunit-console.exe"

task :default => [:clean, :compile, :test]

def build build_config
	solution_name = "#{PROJECT}.sln"
	config = "/p:Configuration=#{build_config} #{solution_name} /t:build /nologo /verbosity:minimal"
	sh "#{MSBUILD_PATH} #{config}"
end

task :clean do
	solution_name = "#{PROJECT}.sln"
	config = "/p:Configuration=#{BUILD_CONFIG} #{solution_name} /t:clean /nologo /verbosity:minimal"
	sh "#{MSBUILD_PATH} #{config}"
end

task :compile => [:clean] do
	build BUILD_CONFIG
end

task :test => [:compile] do
	TEST_PROJECT_NAME = "#{PROJECT}.Tests"
	config = "#{TEST_PROJECT_NAME}/bin/#{BUILD_CONFIG}/#{TEST_PROJECT_NAME}.dll /xml=build/#{TEST_PROJECT_NAME}.xml /nologo"
	sh "#{NUNIT_PATH} #{config}"
end

#rake nuget k=<nuget_access_key>
task :nuget do
	build "NuGet"
	sh 'nuget pack TextHelper.nuspec -b build\nuget -o build\nuget_packages'
	if ENV['k']
		sh "nuget push build\\nuget_packages\\TextHelper.0.1.nupkg #{ENV['k']}"
	end
end