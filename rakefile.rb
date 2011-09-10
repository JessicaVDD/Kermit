require 'rake'
require 'rake/clean'
require 'fileutils'
require 'build/project.rb'
require 'erb'

['build/tools/Rake','build'].each do|pattern|
  Dir.glob(File.join(File.dirname(__FILE__),pattern,"*.rb")).each do|item|
    puts item
    require item
  end
end

#load settings that differ by machine
@database_details = DbDetails.new
@local_settings = LocalSettings.new

COMPILE_TARGET = 'debug'

CLEAN.include(File.join('artifacts',"*.*"),'**/*.sql')

def create_sql_fileset(folder)
  FileList.new(File.join('product','sql',folder,'**/*.sql'))
end

def process_template_file(file)
  database_details = @database_details
  local_settings = @local_settings

  file_name = File.basename(file).name_without_template_extension
  file_name = ".#{file_name}" if (/\.dotfile/ =~ file)
  output = File.join(File.dirname(file),file_name)
  File.delete(output) if File.exists?(output)
  File.open(output,'w') {|converted| converted << ERB.new(File.read(file)).result(binding)}
end

template_code_dir = File.join('product','templated_code')


#configuration files
config_files = FileList.new(File.join('product','config','*.erb')).select{|fn| ! fn.include?('app.config')}

app_config = File.join('product','config','app.config.erb')

def create_sql_fileset(folder)
  FileList.new(File.join('product','sql',folder,'**/*.sql'))
end

#
#target folders that can be run from VS
solution_file = "Kermit.sln"

task :default => ["db:create_schema","specs:run"]

task :init  => :clean do
  ['artifacts',Project.specs_dir,Project.report_folder].each{|folder| mkdir folder if ! File.exists?(folder)}
end

task :expand_all_template_files do
  Dir.glob("**/*.erb") do |file|
    process_template_file(file)
  end
end


desc 'compiles the project'
task :compile => :init do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => solution_file
end

task :from_ide => :expand_all_template_files do
  Project.spec_assemblies.each do |assembly|
      FileUtils.cp(app_config.name_without_template_extension,
      File.join('artifacts',"#{File.basename(assembly)}.config"))
  end

  FileUtils.cp(app_config.name_without_template_extension,File.join(
  Project.startup_dir,Project.startup_config))

  config_files.each do |file|
      ['artifacts',Project.startup_dir].each do|folder|
        FileUtils.cp(file.name_without_template_extension,
        File.join(folder,File.basename(file.name_without_template_extension)))
      end
  end
end

namespace :db do
  desc 'tears down the database and recreates it from the ddl files'
  task :create_schema => [:init,:expand_all_template_files] do
  end

  desc 'loads the database with acceptance testing data'
  task :load_data => :create_schema do
  end
end

namespace :specs do
  desc 'view the spec report'
  task :view do
    puts Project.report_folder
    system "start #{Project.report_folder}/#{Project.name}.specs.html"
  end

  desc 'run the specs for the project'
  task :run  => [:init,:compile] do
    Dir.glob(File.join('thirdparty','developwithpassion.specifications','*')).each do|file|
      FileUtils.cp(file,'artifacts')
    end
    sh "artifacts/mspec-clr4.exe", "--html", "#{Project.report_folder}/#{Project.name}.specs.html", "-x", "example", *([] + Project.spec_assemblies)
  end
end

desc "open the solution"
task :sln do
path = "devenv #{solution_file}"
  Thread.new do
    system path
  end
end
