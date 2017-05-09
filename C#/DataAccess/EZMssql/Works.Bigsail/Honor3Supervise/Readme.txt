PM> GET-HELP Enable-Migrations -FULL

名称
    Enable-Migrations
摘要
    Enables Code First Migrations in a project.
语法
    Enable-Migrations [-ContextTypeName <String>] [-EnableAutomaticMigrations] [-MigrationsDirectory <String>] [-ProjectName <String>] [-StartUpProjectName <String>] [-ContextProjectName <String>] [-ConnectionStringName <String>] [-Force] [-ContextAssemblyName <
    String>] [-AppDomainBaseDirectory <String>] [<CommonParameters>]
    
    Enable-Migrations [-ContextTypeName <String>] [-EnableAutomaticMigrations] [-MigrationsDirectory <String>] [-ProjectName <String>] [-StartUpProjectName <String>] [-ContextProjectName <String>] -ConnectionString <String> -ConnectionProviderName <String> [-For
    ce] [-ContextAssemblyName <String>] [-AppDomainBaseDirectory <String>] [<CommonParameters>]
说明
    Enables Migrations by scaffolding a migrations configuration class in the project. If the
    target database was created by an initializer, an initial migration will be created (unless
    automatic migrations are enabled via the EnableAutomaticMigrations parameter).
参数
    -ContextTypeName <String>
        Specifies the context to use. If omitted, migrations will attempt to locate a
        single context type in the target project.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -EnableAutomaticMigrations [<SwitchParameter>]
        Specifies whether automatic migrations will be enabled in the scaffolded migrations configuration.
        If omitted, automatic migrations will be disabled.
        是否必需?                    False
        位置?                        named
        默认值                False
        是否接受管道输入?            false
        是否接受通配符?              False
    -MigrationsDirectory <String>
        Specifies the name of the directory that will contain migrations code files.
        If omitted, the directory will be named "Migrations".
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ProjectName <String>
        Specifies the project that the scaffolded migrations configuration class will
        be added to. If omitted, the default project selected in package manager
        console is used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -StartUpProjectName <String>
        Specifies the configuration file to use for named connection strings. If
        omitted, the specified project's configuration file is used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ContextProjectName <String>
        Specifies the project which contains the DbContext class to use. If omitted,
        the context is assumed to be in the same project used for migrations.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionStringName <String>
        Specifies the name of a connection string to use from the application's
        configuration file.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionString <String>
        Specifies the the connection string to use. If omitted, the context's
        default connection will be used.
        是否必需?                    True
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionProviderName <String>
        Specifies the provider invariant name of the connection string.
        是否必需?                    True
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -Force [<SwitchParameter>]
        Specifies that the migrations configuration be overwritten when running more
        than once for a given project.
        是否必需?                    False
        位置?                        named
        默认值                False
        是否接受管道输入?            false
        是否接受通配符?              False
    -ContextAssemblyName <String>
        Specifies the name of the assembly which contains the DbContext class to use. Use this
        parameter instead of ContextProjectName when the context is contained in a referenced
        assembly rather than in a project of the solution.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -AppDomainBaseDirectory <String>
        Specifies the directory to use for the app-domain that is used for running Migrations
        code such that the app-domain is able to find all required assemblies. This is an
        advanced option that should only be needed if the solution contains    several projects 
        such that the assemblies needed for the context and configuration are not all
        referenced from either the project containing the context or the project containing
        the migrations.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    <CommonParameters>
        此 Cmdlet 支持通用参数: Verbose、Debug、
        ErrorAction、ErrorVariable、WarningAction、WarningVariable、
        OutBuffer 和 OutVariable。有关详细信息，请参阅
        about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216)。 
输入
输出
    -------------------------- 示例 1 --------------------------
    C:\PS>Enable-Migrations
    # Scaffold a migrations configuration in a project with only one context
    -------------------------- 示例 2 --------------------------
    C:\PS>Enable-Migrations -Auto
    # Scaffold a migrations configuration with automatic migrations enabled for a project
    # with only one context
    -------------------------- 示例 3 --------------------------
    C:\PS>Enable-Migrations -ContextTypeName MyContext -MigrationsDirectory DirectoryName
    # Scaffold a migrations configuration for a project with multiple contexts
    # This scaffolds a migrations configuration for MyContext and will put the configuration
    # and subsequent configurations in a new directory called "DirectoryName"

PM> Enable-Migrations -ContextTypeName EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3SuperviseContext -MigrationsDirectory EZMssql\Works.Bigsail\Honor3Supervise

正在检查上下文的目标是否为现有数据库...
已为项目 DataAccess 启用 Code First 迁移。
---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
PM> GET-HELP Update-Database -FULL

名称
    Update-Database
摘要
    Applies any pending migrations to the database.
语法
    Update-Database [-SourceMigration <String>] [-TargetMigration <String>] [-Script] [-Force] [-ProjectName <String>] [-StartUpProjectName <String>] [-ConfigurationTypeName <String>] [-ConnectionStringName <String>] [-AppDomainBaseDirectory <String>] [<CommonPa
    rameters>]
    
    Update-Database [-SourceMigration <String>] [-TargetMigration <String>] [-Script] [-Force] [-ProjectName <String>] [-StartUpProjectName <String>] [-ConfigurationTypeName <String>] -ConnectionString <String> -ConnectionProviderName <String> [-AppDomainBaseDir
    ectory <String>] [<CommonParameters>]
说明
    Updates the database to the current model by applying pending migrations.
参数
    -SourceMigration <String>
        Only valid with -Script. Specifies the name of a particular migration to use
        as the update's starting point. If omitted, the last applied migration in
        the database will be used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -TargetMigration <String>
        Specifies the name of a particular migration to update the database to. If
        omitted, the current model will be used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -Script [<SwitchParameter>]
        Generate a SQL script rather than executing the pending changes directly.
        是否必需?                    False
        位置?                        named
        默认值                False
        是否接受管道输入?            false
        是否接受通配符?              False
    -Force [<SwitchParameter>]
        Specifies that data loss is acceptable during automatic migration of the
        database.
        是否必需?                    False
        位置?                        named
        默认值                False
        是否接受管道输入?            false
        是否接受通配符?              False
    -ProjectName <String>
        Specifies the project that contains the migration configuration type to be
        used. If omitted, the default project selected in package manager console
        is used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -StartUpProjectName <String>
        Specifies the configuration file to use for named connection strings. If
        omitted, the specified project's configuration file is used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConfigurationTypeName <String>
        Specifies the migrations configuration to use. If omitted, migrations will
        attempt to locate a single migrations configuration type in the target
        project.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionStringName <String>
        Specifies the name of a connection string to use from the application's
        configuration file.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionString <String>
        Specifies the the connection string to use. If omitted, the context's
        default connection will be used.
        是否必需?                    True
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionProviderName <String>
        Specifies the provider invariant name of the connection string.
        是否必需?                    True
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -AppDomainBaseDirectory <String>
        Specifies the directory to use for the app-domain that is used for running Migrations
        code such that the app-domain is able to find all required assemblies. This is an
        advanced option that should only be needed if the solution contains    several projects 
        such that the assemblies needed for the context and configuration are not all
        referenced from either the project containing the context or the project containing
        the migrations.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    <CommonParameters>
        此 Cmdlet 支持通用参数: Verbose、Debug、
        ErrorAction、ErrorVariable、WarningAction、WarningVariable、
        OutBuffer 和 OutVariable。有关详细信息，请参阅
        about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216)。 
输入
输出
    -------------------------- 示例 1 --------------------------
    C:\PS>Update-Database
    # Update the database to the latest migration
    -------------------------- 示例 2 --------------------------
    C:\PS>Update-Database -TargetMigration Second
    # Update database to a migration named "Second"
    # This will apply migrations if the target hasn't been applied or roll back migrations
    # if it has
    -------------------------- 示例 3 --------------------------
    C:\PS>Update-Database -Script
    # Generate a script to update the database from it's current state  to the latest migration
    -------------------------- 示例 4 --------------------------
    C:\PS>Update-Database -Script -SourceMigration Second -TargetMigration First
    # Generate a script to migrate the database from a specified start migration
    # named "Second" to a specified target migration named "First"
    -------------------------- 示例 5 --------------------------
    C:\PS>Update-Database -Script -SourceMigration $InitialDatabase
    # Generate a script that can upgrade a database currently at any version to the latest version. 
    # The generated script includes logic to check the __MigrationsHistory table and only apply changes 
    # that haven't been previously applied.
    -------------------------- 示例 6 --------------------------
    C:\PS>Update-Database -TargetMigration $InitialDatabase
    # Runs the Down method to roll-back any migrations that have been applied to the database

PM> Update-Database -ConfigurationTypeName EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3Supervise.Configuration -Verbose

Using StartUp project 'CSharpWebSI'.
Using NuGet project 'DataAccess'.
指定“-Verbose”标志以查看应用于目标数据库的 SQL 语句。
目标数据库为: “WorksBigsailHonor3Supervise”(DataSource: localhost\MSSQLE14，提供程序: System.Data.SqlClient，来源: Configuration)。
没有挂起的显式迁移。
正在运行 Seed 方法。
---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
PM> GET-HELP Add-Migration -FULL

名称
    Add-Migration
摘要
    Scaffolds a migration script for any pending model changes.
语法
    Add-Migration [-Name] <String> [-Force] [-ProjectName <String>] [-StartUpProjectName <String>] [-ConfigurationTypeName <String>] [-ConnectionStringName <String>] [-IgnoreChanges] [-AppDomainBaseDirectory <String>] [<CommonParameters>]
    
    Add-Migration [-Name] <String> [-Force] [-ProjectName <String>] [-StartUpProjectName <String>] [-ConfigurationTypeName <String>] -ConnectionString <String> -ConnectionProviderName <String> [-IgnoreChanges] [-AppDomainBaseDirectory <String>] [<CommonParameters>]
说明
    Scaffolds a new migration script and adds it to the project.
参数
    -Name <String>
        Specifies the name of the custom script.
        是否必需?                    True
        位置?                        1
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -Force [<SwitchParameter>]
        Specifies that the migration user code be overwritten when re-scaffolding an
        existing migration.
        是否必需?                    False
        位置?                        named
        默认值                False
        是否接受管道输入?            false
        是否接受通配符?              False
    -ProjectName <String>
        Specifies the project that contains the migration configuration type to be
        used. If omitted, the default project selected in package manager console
        is used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -StartUpProjectName <String>
        Specifies the configuration file to use for named connection strings. If
        omitted, the specified project's configuration file is used.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConfigurationTypeName <String>
        Specifies the migrations configuration to use. If omitted, migrations will
        attempt to locate a single migrations configuration type in the target
        project.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionStringName <String>
        Specifies the name of a connection string to use from the application's
        configuration file.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionString <String>
        Specifies the the connection string to use. If omitted, the context's
        default connection will be used.
        是否必需?                    True
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -ConnectionProviderName <String>
        Specifies the provider invariant name of the connection string.
        
        是否必需?                    True
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    -IgnoreChanges [<SwitchParameter>]
        Scaffolds an empty migration ignoring any pending changes detected in the current model.
        This can be used to create an initial, empty migration to enable Migrations for an existing
        database. N.B. Doing this assumes that the target database schema is compatible with the
        current model.
        是否必需?                    False
        位置?                        named
        默认值                False
        是否接受管道输入?            false
        是否接受通配符?              False
    -AppDomainBaseDirectory <String>
        Specifies the directory to use for the app-domain that is used for running Migrations
        code such that the app-domain is able to find all required assemblies. This is an
        advanced option that should only be needed if the solution contains    several projects 
        such that the assemblies needed for the context and configuration are not all
        referenced from either the project containing the context or the project containing
        the migrations.
        是否必需?                    False
        位置?                        named
        默认值                
        是否接受管道输入?            false
        是否接受通配符?              False
    <CommonParameters>
        此 Cmdlet 支持通用参数: Verbose、Debug、
        ErrorAction、ErrorVariable、WarningAction、WarningVariable、
        OutBuffer 和 OutVariable。有关详细信息，请参阅
        about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216)。 
输入
输出
    -------------------------- 示例 1 --------------------------
    C:\PS>Add-Migration First
    # Scaffold a new migration named "First"
    -------------------------- 示例 2 --------------------------
    C:\PS>Add-Migration First -IgnoreChanges
    # Scaffold an empty migration ignoring any pending changes detected in the current model.
    # This can be used to create an initial, empty migration to enable Migrations for an existing
    # database. N.B. Doing this assumes that the target database schema is compatible with the
    # current model.

PM> Add-Migration AddInitDatabase -ConfigurationTypeName EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3Supervise.Configuration

正在为迁移“AddInitDatabase”搭建基架。
此迁移文件的设计器代码包含当前 Code First 模型的快照。在下一次搭建迁移基架时，将使用此快照计算对模型的更改。如果对要包含在此迁移中的模型进行其他更改，则您可通过再次运行“Add-Migration AddInitDatabase”重新搭建基架。
---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
PM> Update-Database -ConfigurationTypeName EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3Supervise.Configuration -Verbose