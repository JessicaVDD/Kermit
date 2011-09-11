class LocalSettings 
 def create_settings_dictionary()
  settings = {
  	:path_to_runtime_log4net_config => File.join(%w[artifacts log4net.config.xml]),
  	:browser_exe => File.join(ENV['SYSTEMDRIVE'],'program files','mozilla firefox','firefox.exe'),
  	:log_file_name => "willow_log.txt",
  	:log_level => "DEBUG",
  	:xunit_report_file_dir => "artifacts" ,
  	:xunit_report_file_name => "test_report",
  	:xunit_report_type => "text",
  	:xunit_show_test_report => true,
  	:debug => "TRUE",
  }
 end
end
