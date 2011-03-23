require 'rexml/document'
include REXML

PROJECT_NAME = "TextHelper"
BUILD_CONFIG = "Debug"
MSBUILD_PATH = "C:/Windows/Microsoft.NET/Framework/v4.0.30319/msbuild.exe"
NUNIT_PATH = "packages/NUnit.2.5.9.10348/tools/nunit-console.exe"

task :default => [:clean, :compile, :test]

def build build_config
	solution_name = "#{PROJECT_NAME}.sln"
	config = "/p:Configuration=#{build_config} #{solution_name} /t:build /nologo /verbosity:minimal"
	sh "#{MSBUILD_PATH} #{config}"
end

def package_nuget
	build "NuGet"
	sh "nuget pack #{PROJECT_NAME}.nuspec -b build\\nuget -o build\\nuget_packages"
end

def update_nuspec_version version
	#package//metadata/version
	config = nil
	File.open("#{PROJECT_NAME}.nuspec", 'r') do |config_file|
		config = Document.new(config_file)
		node = config.root.elements['metadata/version']
		node.text = version.to_s
	end
	
	formatter = REXML::Formatters::Default.new
	File.open("#{PROJECT_NAME}.nuspec", 'w') do |result|
		formatter.write(config, result)
	end
end

task :clean do
	solution_name = "#{PROJECT_NAME}.sln"
	config = "/p:Configuration=#{BUILD_CONFIG} #{solution_name} /t:clean /nologo /verbosity:minimal"
	sh "#{MSBUILD_PATH} #{config}"
end

task :compile => [:clean] do
	build BUILD_CONFIG
end

task :test => [:compile] do
	TEST_PROJECT_NAME = "#{PROJECT_NAME}.Tests"
	config = "#{TEST_PROJECT_NAME}/bin/#{BUILD_CONFIG}/#{TEST_PROJECT_NAME}.dll /xml=build/#{TEST_PROJECT_NAME}.xml /nologo"
	sh "#{NUNIT_PATH} #{config}"
end

task :package do
	package_nuget
end

#rake nuget v=0.3.0 k=<nuget_access_key>
task :publish do
	if ENV['v']
		update_nuspec_version "#{ENV['v']}"
		package_nuget
		if ENV['k']
			sh "nuget push build\\nuget_packages\\#{PROJECT_NAME}#{ENV['v']}.nupkg #{ENV['k']}"
		end
	end
end