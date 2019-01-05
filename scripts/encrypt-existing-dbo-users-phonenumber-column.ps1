Import-Module SqlServer
# If missing install using command: Install-Module -Name SqlServer -AllowClobber

# Set up connection and database SMO objects
$sqlConnectionString = "Data Source=.;Initial Catalog=FakeMobileCarrierDb;Integrated Security=True;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Packet Size=4096;Application Name=`"Microsoft SQL Server Management Studio`""
$smoDatabase = Get-SqlDatabase -ConnectionString $sqlConnectionString

# Change encryption schema
$encryptionChanges = @()

# Add changes for table [dbo].[Users]
$encryptionChanges += New-SqlColumnEncryptionSettings -ColumnName dbo.Users.PhoneNumber -EncryptionType Deterministic -EncryptionKey "CEK_dbo_Users_PhoneNumber"

Set-SqlColumnEncryption -ColumnEncryptionSettings $encryptionChanges -InputObject $smoDatabase