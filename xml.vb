Imports System.Xml
Imports System.IO

Public Class xml


    Public Function read(file As String) As messaggio
    	
    	Dim u As New messaggio
    	
        
        Dim m_xmlr As XmlTextReader
        'Create the XML Reader
        m_xmlr = New XmlTextReader(file)
        'Disable whitespace so that you don't have to read over whitespaces
        m_xmlr.WhitespaceHandling = WhitespaceHandling.None
        
        m_xmlr.Read()
        m_xmlr.Read()
        m_xmlr.Read()
        m_xmlr.Read()
        
        u.file.percorso = m_xmlr.ReadElementString("percorso")
        u.file.percorso=file
        u.file.nomefile= m_xmlr.ReadElementString("nomefile")
        
        u.file.utente= m_xmlr.ReadElementString("utente")
        u.file.macchina= m_xmlr.ReadElementString("macchina")
        u.file.tipo= m_xmlr.ReadElementString("tipo")
        u.file.nometipo= m_xmlr.ReadElementString("nometipo")
        
        m_xmlr.Read()
        
        u.titolo = m_xmlr.ReadElementString("titolo")
        u.corpo = m_xmlr.ReadElementString("corpo")
         
        m_xmlr.Read()
       
                u.script.tipologia = m_xmlr.ReadElementString("tipologia")
                u.script.comando = m_xmlr.ReadElementString("comando")
                u.script.opzioni = m_xmlr.ReadElementString("opzioni")
       
             
                Try
                    Do While 1 = 1
                        u.script.listato.Add ( m_xmlr.ReadElementString("listato"))
                    Loop
                Catch ex As Exception
					Debug.Print(ex.Message)
                End Try

            m_xmlr.Close()
            Return u
    End Function



    Private Sub createutente(u As messaggio, ByVal writer As XmlTextWriter)
	
	writer.WriteStartElement("file")
	writer.WriteStartElement("percorso")
        writer.WriteString(u.file.percorso)
        writer.WriteEndElement()
        
        writer.WriteStartElement("nomefile")
        writer.WriteString(u.file.nomefile)
        writer.WriteEndElement()
         writer.WriteStartElement("utente")
        writer.WriteString(u.file.utente)
        writer.WriteEndElement()
        
          writer.WriteStartElement("macchina")
        writer.WriteString(u.file.macchina)
        writer.WriteEndElement()
        
         writer.WriteStartElement("tipo")
        writer.WriteString(u.file.tipo)
        writer.WriteEndElement()
         writer.WriteStartElement("nometipo")
        writer.WriteString(u.file.nometipo)
        writer.WriteEndElement()
         writer.WriteEndElement()
        
        
        
        writer.WriteStartElement("titolo")
        writer.WriteString(u.titolo)
        writer.WriteEndElement()

        writer.WriteStartElement("corpo")
        writer.WriteString(u.corpo)
        writer.WriteEndElement()
        
        writer.WriteStartElement("script")
        'writer.WriteEndElement()
        writer.WriteStartElement("tipologia")
        writer.WriteString(u.script.tipologia)
        writer.WriteEndElement()
        
        writer.WriteStartElement("comando")
        writer.WriteString(u.script.comando)
        writer.WriteEndElement()
        
        writer.WriteStartElement("opzioni")
        writer.WriteString(u.script.opzioni)
        writer.WriteEndElement()

        
		
		For x As Integer=0 To u.script.listato.Count-1
			writer.WriteStartElement("listato")
			writer.WriteString(u.script.listato(x))
			writer.WriteEndElement()
		Next
		writer.WriteEndElement()
		
		

    End Sub
End Class