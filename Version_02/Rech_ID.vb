Module Rech_ID
    '   RECHERCHRE DES IDENTIFIANTS DES REGARDS ET TRONCONS
    Public Sub Commande_Rech_ID()
        Cursor.Current = Cursors.WaitCursor : ID_Des_Regards() : Cursor.Current = Cursors.Default
    End Sub
    Public Sub Commande_Rech_Canalisation()
        Cursor.Current = Cursors.WaitCursor
        ID_Des_Canas()
        Num_ID_Des_Canas()
        MaJ_BT_Validations
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ID_Des_Regards()
        '   Recherche les identifiant des regards
        '   Boucle sur le DataView Regards
        For I = 0 To Fm_01.DataGridView1.Rows.Count - 1
            ' Si colonne ID_Sig est  null --> Rechercher le numéro
            Dim Sql_Rech As String
            If Fm_01.DataGridView1.Rows(I).Cells(1).Value = "" And Fm_01.DataGridView1.Rows(I).Cells(2).Value = "" Then
                '   --> Si Id_TXT commence par R_
                If Left(Fm_01.DataGridView1.Rows(I).Cells(0).Value, 2) = "R_" And Fm_01.DataGridView1.Rows(I).Cells(1).Value = "" Then
                    Sql_Rech = "select id_regard from test.num_regard where  nom_ouvrage = '" & Fm_01.DataGridView1.Rows(I).Cells(0).Value & "'"
                    Fm_01.DataGridView1.Rows(I).Cells(1).Value = SQL_Recherche(Sql_Rech)
                    Fm_01.DataGridView1.Rows(I).Cells(2).Value = Fm_01.DataGridView1.Rows(I).Cells(0).Value
                    Fm_01.Refresh()
                Else
                    '  --> Pour Id_Regard
                    Sql_Rech = "select id_regard from test.num_regard where old_num = '" & Fm_01.DataGridView1.Rows(I).Cells(0).Value & "'"
                    Fm_01.DataGridView1.Rows(I).Cells(1).Value = SQL_Recherche(Sql_Rech) : Fm_01.Refresh()
                    '   --> Si ID_Regard trouvé
                    If Fm_01.DataGridView1.Rows(I).Cells(1).Value <> "" Then
                        Sql_Rech = "select nom_ouvrage from test.num_regard where id_regard = '" & Fm_01.DataGridView1.Rows(I).Cells(1).Value & "'"
                        Fm_01.DataGridView1.Rows(I).Cells(2).Value = SQL_Recherche(Sql_Rech) : Fm_01.Refresh()
                    End If
                End If
            Else
                '       Si ID_sig n'est pas vide et Num_regards est vide
                If Fm_01.DataGridView1.Rows(I).Cells(1).Value <> "" And Fm_01.DataGridView1.Rows(I).Cells(2).Value = "" Then
                    Sql_Rech = "select nom_ouvrage from test.num_regard where id_regard = '" & Fm_01.DataGridView1.Rows(I).Cells(1).Value & "'"
                    Fm_01.DataGridView1.Rows(I).Cells(2).Value = SQL_Recherche(Sql_Rech) : Fm_01.Refresh()
                End If
            End If
            Fm_01.Refresh()
        Next
        Fm_01.Bt_Id_Troncon.Visible = True
    End Sub

    Public Sub ID_Des_Canas()
        ' Boucle sur DataViewTroncon
        For I = 0 To Fm_01.DataViewTronco.Rows.Count - 1
            '   --> Mise à jours des Numéros de regards dans DataView Tronçons
            '   Si Id_SIG_01 est vide
            If Fm_01.DataViewTronco.Rows(I).Cells(1).Value = "" Then
                For J = 0 To Fm_01.DataGridView1.Rows.Count - 1
                    If Fm_01.DataViewTronco.Rows(I).Cells(0).Value = Fm_01.DataGridView1.Rows(J).Cells(0).Value Then
                        Fm_01.DataViewTronco.Rows(I).Cells(1).Value = Fm_01.DataGridView1.Rows(J).Cells(2).Value
                        Exit For
                    End If
                Next
            End If
            '   Si Id_SIG_02 est vide
            If Fm_01.DataViewTronco.Rows(I).Cells(3).Value = "" Then
                For J = 0 To Fm_01.DataGridView1.Rows.Count - 1
                    If Fm_01.DataViewTronco.Rows(I).Cells(2).Value = Fm_01.DataGridView1.Rows(J).Cells(0).Value Then
                        Fm_01.DataViewTronco.Rows(I).Cells(3).Value = Fm_01.DataGridView1.Rows(J).Cells(2).Value
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub Num_ID_Des_Canas()
        '   Recherche si les canalisations existes
        For I = 0 To Fm_01.DataViewTronco.Rows.Count - 1
            '   Si Id_Troncon est vide
            If Fm_01.DataViewTronco.Rows(I).Cells(4).Value = "" And Fm_01.DataViewTronco.Rows(I).Cells(1).Value <> "" And Fm_01.DataViewTronco.Rows(I).Cells(3).Value <> "" Then
                '   Si sens Direct
                Dim Sql_Rech As String
                If Fm_01.DataViewTronco.Rows(I).Cells(5).Value = "Direct" Then
                    Sql_Rech = "select id_cana from test.num_canalisation where  num_amont = '" & Fm_01.DataViewTronco.Rows(I).Cells(1).Value & "' and "
                    Sql_Rech += "num_aval = '" & Fm_01.DataViewTronco.Rows(I).Cells(3).Value & "'  "
                Else
                    Sql_Rech = "select id_cana from test.num_canalisation where  num_amont = '" & Fm_01.DataViewTronco.Rows(I).Cells(3).Value & "' and "
                    Sql_Rech += "num_aval = '" & Fm_01.DataViewTronco.Rows(I).Cells(1).Value & "'  "
                End If
                Fm_01.DataViewTronco.Rows(I).Cells(4).Value = SQL_Recherche(Sql_Rech) : Fm_01.Refresh()
            End If
        Next
        Fm_01.Refresh()
    End Sub

    Public Sub MaJ_BT_Validations()
        '   MISE A JOUR DES BOUTONS DE VALIDATION
        With Fm_01
            .Bt_Mise_Attente.Visible = False
            .Bt_Deux_Dossier.Visible = False
            .Bt_Valid_Incorpo.Visible = False
        End With
        Fm_01.Refresh()
        Dim Nb_tr As Integer = Fm_01.DataViewTronco.Rows.Count - 1 + 1
        Dim Nb_OK As Integer = 0
        For I = 0 To Fm_01.DataViewTronco.Rows.Count - 1
            If Fm_01.DataViewTronco.Rows(I).Cells(4).Value <> "" Then Nb_OK += 1
        Next
        With Fm_01
            If Nb_OK = Nb_tr Then
                .Bt_Mise_Attente.Visible = False
                .Bt_Deux_Dossier.Visible = False
                .Bt_Valid_Incorpo.Visible = True
            Else
                If Nb_OK > 0 Then
                    .Bt_Mise_Attente.Visible = True
                    .Bt_Deux_Dossier.Visible = True
                    .Bt_Valid_Incorpo.Visible = False
                Else
                    .Bt_Mise_Attente.Visible = True
                    .Bt_Deux_Dossier.Visible = False
                    .Bt_Valid_Incorpo.Visible = False
                End If
            End If
        End With
        Fm_01.Refresh()
    End Sub
End Module
