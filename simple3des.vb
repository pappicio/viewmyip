'
' Creato da SharpDevelop.
' Utente: io
' Data: 05/01/2017
' Ora: 09:55
' 
' Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
'
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Friend Class Simple3Des
	
	
	
	
	
Public Shared Function EncryptData(ByVal Message As String, ByVal Passphrase As String) As String
        Dim Results() As Byte
        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding
        ' Step 1. We hash the Passphrase using MD5
        ' We use the MD5 hash generator as the result is a 128 bit byte array
        ' which is a valid length for the TripleDES encoder we use below
        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase))

            ' Step 2. Create a new TripleDESCryptoServiceProvider object

            ' Step 3. Setup the encoder
            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider() 'With 
            	TDESAlgorithm.Key = TDESKey
            	TDESAlgorithm.Mode = CipherMode.ECB
            	TDESAlgorithm.Padding = PaddingMode.PKCS7
                ' Step 4. Convert the input string to a byte[]

                Dim DataToEncrypt() As Byte = UTF8.GetBytes(Message)

                ' Step 5. Attempt to encrypt the string
                Try
                    Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)
                Finally
                    ' Clear the TripleDes and Hashprovider services of any sensitive information
                    TDESAlgorithm.Clear()
                    HashProvider.Clear()
                End Try
            End Using
        End Using

        ' Step 6. Return the encrypted string as a base64 encoded string
        Return Convert.ToBase64String(Results)
    End Function

    Public Shared Function DecryptData(ByVal Message As String, ByVal Passphrase As String) As String
        Dim Results() As Byte
        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding

        ' Step 1. We hash the Pass phrase using MD5
        ' We use the MD5 hash generator as the result is a 128 bit byte array
        ' which is a valid length for the TripleDES encoder we use below
        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase))

            ' Step 2. Create a new TripleDESCryptoServiceProvider object
            ' Step 3. Setup the decoder
            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
            	TDESAlgorithm.Key = TDESKey 
            	TDESAlgorithm.Mode = CipherMode.ECB
            	TDESAlgorithm.Padding = PaddingMode.PKCS7

                ' Step 4. Convert the input string to a byte[]
                Dim DataToDecrypt() As Byte = Convert.FromBase64String(Message)
                ' Step 5. Attempt to decrypt the string
                Try
                    Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)
                Finally

                    ' Clear the TripleDes and Hash provider services of any sensitive information
                    TDESAlgorithm.Clear()
                    HashProvider.Clear()
                End Try
            End Using
        End Using

        ' Step 6. Return the decrypted string in UTF8 format
        Return UTF8.GetString(Results)
    End Function

End Class