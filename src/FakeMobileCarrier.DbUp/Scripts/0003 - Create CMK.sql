create column master key [CMK_dbo_Users_PhoneNumber]
with
(
	key_store_provider_name = N'MSSQL_CERTIFICATE_STORE',
	key_path = N'CurrentUser/My/C5626AB3DC6750A653A7DF43C9BF4C57CFCE3ED1'
)