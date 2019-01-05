$certFilePath = "..\certificates\FCA2F7B54CC3A3A80C478A418C600205325C6757.pfx"
$certStoreLocation = "Cert:CurrentUser\My"
$certSecuredPassword = ConvertTo-SecureString "Abc123" -AsPlainText -Force

Import-PfxCertificate -FilePath $certFilePath -CertStoreLocation $certStoreLocation -Password $certSecuredPassword