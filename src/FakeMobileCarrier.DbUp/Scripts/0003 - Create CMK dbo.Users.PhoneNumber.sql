create column master key [CMK_dbo_Users_PhoneNumber]
with
(
	key_store_provider_name = N'MSSQL_CERTIFICATE_STORE',
	key_path = N'CurrentUser/My/FCA2F7B54CC3A3A80C478A418C600205325C6757'
)