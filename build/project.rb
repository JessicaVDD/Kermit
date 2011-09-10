class Project
  class << self
    def name
      @name = "tech"
    end

    def startup_dir
      @startup_dir = File.join(%w[artifacts])
    end

    def specs_dir
      @specs_dir = File.join(%w[artifacts specs])
    end

    def report_folder
      @report_folder = File.join(%w[artifacts specs report]) 
    end

    def spec_assemblies
      @spec_assemblies = Dir.glob(File.join('artifacts',"willow.kermit*specs.dll"))
    end

    def startup_config
      @startup_config = "app.config"
    end

    def startup_extension
      @startup_extension = ".dll"
    end
  end
end
