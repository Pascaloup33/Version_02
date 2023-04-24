Module DECLARATIONS

    '          --> SERVEUR LOCAL PC LOCAL HP  
    Public Const Con_Prod As String = "Dsn=Postgres_PC_Local;datase=eloasig;server=localhost;port=5432;uid=postgres;pwd=eloa"

    '         --> SERVEUR LOCAL PC PORTABLE EN LOCAL
    '    Public Const Con_Prod As String = "Dsn=PostgreSQL30;datase=eloasig;server=localhost;port=5432;uid=postgres;pwd=eloa"



    '   Chemin du disque DUR
    Public Const Chemin_lecteur As String = "D:\ITV\"
    Public Repertoire_fichier As String
    Public Nom_Fichier_txt As String
    Public choix_fichier_complet As String

    Public Tb_TXT() '   Tableau des ligne du TXT

    Public Function SQL_Recherche(Rsql)
        '   Lance une recherche dans la base de données
        Dim MyConn As New System.Data.Odbc.OdbcConnection With {.ConnectionString = Con_Prod}
        Dim MyCommand As New Odbc.OdbcCommand(Rsql, MyConn)
        MyConn.Open()
        On Error GoTo Rech_count_null
        Dim MyReader As System.Data.Odbc.OdbcDataReader
        MyReader = MyCommand.ExecuteReader
        Do While MyReader.Read() : SQL_Recherche = MyReader.GetValue(0) : Loop
        MyConn.Close()
        Exit Function
Rech_count_null:
        MyConn.Close()
        SQL_Recherche = ""
    End Function


End Module
