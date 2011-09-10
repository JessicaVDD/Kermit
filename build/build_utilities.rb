class LocalSettings
  attr_reader :settings
  

  def [](setting)
    @settings[setting]
  end

  def initialize()
    @settings = create_settings_dictionary
  end

end

class MSBuildRunner
	def self.compile(attributes)
		version = attributes.fetch(:clrversion, 'v4.0.30319')
		compile_target = attributes.fetch(:compile_target, 'debug')
	    solution_file = attributes[:solution_file]
		
		framework_dir = File.join(ENV['WINDIR'].dup, 'Microsoft.NET', 'Framework', 'v4.0.30319')
		msbuild_file = File.join(framework_dir, 'msbuild.exe')
		
		sh "#{msbuild_file} #{solution_file} /property:Configuration=#{compile_target} /t:Rebuild"
	end
end

class String
  def remove_template_name
    self.gsub(/\.erb/,"")
  end
end
class File
  def self.open_for_read(file)
     File.open(file,'r').each do|line|
       yield line
     end
  end

  def self.read_all_text(file)
    contents = ''
    File.open_for_read(file) do |line|
      contents += line
    end
  end

  def self.delete?(file)
    File.delete(file) if File.exists?(file)
  end

  def self.open_for_write(file)
     File.open(file,'w') do|new_file|
       yield new_file
     end
  end

  def self.base_name_without_extensions(file)
    File.basename(file,'.*')
  end


end

class String
  def name_without_template_extension
    return self.gsub(/\.erb/,"")
  end
end
