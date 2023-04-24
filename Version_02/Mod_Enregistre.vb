Imports System.IO

Module Mod_Enregistre
    Public Nom_Repertoire_Courant_Attente As String
    Public Nom_Repertoire_Courant_Validation

    Public Old_commune As String : Public New_commune As String

    Public Sub Type_Enregistrement(Typo)

        Select Case Typo
            Case "1"    'Mod_Mise_en_attente()
                Nom_Repertoire_Courant_Attente = Chemin_lecteur & "02 - En attente\" & IO.Path.GetFileNameWithoutExtension(Fm_01.Text_Nom_ITV.Text)
                If Directory.Exists(Nom_Repertoire_Courant_Attente) = False Then My.Computer.FileSystem.CreateDirectory(Nom_Repertoire_Courant_Attente)
                Mod_Mise_en_attente()

            Case "2"    ' Mod_Deux_Fichier
                Nom_Repertoire_Courant_Attente = Chemin_lecteur & "02 - En attente\" & IO.Path.GetFileNameWithoutExtension(Fm_01.Text_Nom_ITV.Text)
                If Directory.Exists(Nom_Repertoire_Courant_Attente) = False Then My.Computer.FileSystem.CreateDirectory(Nom_Repertoire_Courant_Attente)

                Nom_Repertoire_Courant_Validation = Chemin_lecteur & "03 - A incorporer\" & IO.Path.GetFileNameWithoutExtension(Fm_01.Text_Nom_ITV.Text)
                If Directory.Exists(Nom_Repertoire_Courant_Validation) = False Then My.Computer.FileSystem.CreateDirectory(Nom_Repertoire_Courant_Validation)

                Mod_Deux_Fichier()

            Case "3"    ' Mod_Validation
                Nom_Repertoire_Courant_Validation = Chemin_lecteur & "03 - A incorporer\" & IO.Path.GetFileNameWithoutExtension(Fm_01.Text_Nom_ITV.Text)
                If Directory.Exists(Nom_Repertoire_Courant_Validation) = False Then My.Computer.FileSystem.CreateDirectory(Nom_Repertoire_Courant_Validation)
                Mod_Validation()
        End Select

        MsgBox("NE PAS OUBLIER DE DELACER LES FICHIERS PDF ET PHOTOS")

    End Sub

    Public Sub Mod_Mise_en_attente()
        ' Enregistre le TXT dans Répertoire EN ATTENTE avec les num_regard SIG
        Dim New_TxT As New IO.StreamWriter(CStr(Nom_Repertoire_Courant_Attente & "\" & Fm_01.Text_Nom_ITV.Text & ".txt"))
        Dim Nb_Troncon As Integer = -1
        For I = 0 To UBound(Tb_TXT)
            If Left(Tb_TXT(I), 4) = "#B01" Then
                New_TxT.WriteLine(Tb_TXT(I))
                I += 1
                Nb_Troncon += 1
                Dim Rg_01 As String : Dim Rg_02 As String
                ' Remplace le Rg_01 s'il existe
                Rg_01 = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(0).Value
                Rg_02 = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(1).Value
                If Rg_02 <> "" Then
                    Tb_TXT(I) = Replace(Tb_TXT(I), Rg_01, Rg_02)
                End If
                ' Remplace le Rg_02 s'il existe
                Rg_01 = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(2).Value
                Rg_02 = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(3).Value
                If Rg_02 <> "" Then
                    Tb_TXT(I) = Replace(Tb_TXT(I), Rg_01, Rg_02)
                End If
            End If
            '  Enregistre la ligne
            New_TxT.writeline(Tb_TXT(I))
        Next
        New_TxT.Close()
    End Sub

    Public Sub Mod_Deux_Fichier()
        Dim Fichier_ok(0) : Dim Fichier_a_revoir(0)
        Dim Ok As Integer = 0 : Dim Revoir As Integer = 0
        Dim Nb_Troncon As Double
        Nb_Troncon = -1
        For I = 0 To UBound(Tb_TXT)
            ' --> pour les premières lignes avant le 1er troncon dans les deux fichiers
            If Left(Tb_TXT(I), 4) <> "#B01" And Nb_Troncon = -1 Then
                Fichier_ok(Ok) = Tb_TXT(I) : Ok += 1 : ReDim Preserve Fichier_ok(Ok)
                Fichier_a_revoir(Revoir) = Tb_TXT(I) : Revoir += 1 : ReDim Preserve Fichier_a_revoir(Revoir)
            End If
            ' --> sur ligne troncon (#B01)
            If Left(Tb_TXT(I), 4) = "#B01" Then Nb_Troncon += 1

            If Nb_Troncon > -1 Then
                '   --> si le troncon a un ID canalisation trouvé dans DataViewTroncon
                If Len(Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(4).Value) > 1 And Left(Tb_TXT(I), 4) = "#B01" Then
                    '   --> Ajout ABH ABO (Nom inspecteur, Nom ITV  -->  SIBA ou Eloa, Nom de fichier)
                    Tb_TXT(I) = Tb_TXT(I) & ";ABH;ABN"
                    '       --> on enregistre la 1er ligne #B01
                    Fichier_ok(Ok) = Tb_TXT(I) : Ok += 1 : ReDim Preserve Fichier_ok(Ok)
                    '   -> On passe à la ligne suivante pour saisir ABHn ABO
                    Tb_TXT(I + 1) = Tb_TXT(I + 1) & ";""" & Fm_01.T_Type_ITV.SelectedItem & """;""" & Fm_01.Text_Nom_ITV.Text & """"
                    '   -->  Vérification de la commune
                    If New_commune = "" Then
                        New_commune = Rech_Commune(Tb_TXT(I), Tb_TXT(I + 1))
                    End If
                    Tb_TXT(I + 1) = Replace(Tb_TXT(I + 1), Old_commune, New_commune)
                    '       --> on enregistre toutes les lignes suivante jusqu' "#Z" ou null ou fin du tableau Tb_TXT  
                    Do
                            I += 1
                            '       --> on remplace les id_regard txt par les ID Géo et on enregistre
                            '   Rg_01
                            Dim Num_New As String = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(1).Value
                            If Len(Num_New) > 1 Then
                                For J = 0 To Fm_01.DataGridView1.Rows.Count
                                    If Fm_01.DataGridView1.Rows(J).Cells(2).Value = Num_New Then
                                        Tb_TXT(I) = Replace(Tb_TXT(I), Fm_01.DataGridView1.Rows(J).Cells(0).Value, Fm_01.DataGridView1.Rows(J).Cells(1).Value)
                                        Exit For
                                    End If
                                Next
                            End If
                            '   Rg_02
                            Num_New = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(3).Value
                            If Len(Num_New) > 1 Then
                                For J = 0 To Fm_01.DataGridView1.Rows.Count
                                    If Fm_01.DataGridView1.Rows(J).Cells(2).Value = Num_New Then
                                        Tb_TXT(I) = Replace(Tb_TXT(I), Fm_01.DataGridView1.Rows(J).Cells(0).Value, Fm_01.DataGridView1.Rows(J).Cells(1).Value)
                                        Exit For
                                    End If
                                Next
                            End If
                            Fichier_ok(Ok) = Tb_TXT(I) : Ok += 1 : ReDim Preserve Fichier_ok(Ok)
                        Loop Until Left(Tb_TXT(I), 2) = "#Z" Or Tb_TXT(I) = "" Or I = UBound(Tb_TXT)
                    End If
                    '   --> si le troncon n'a pas  un ID canalisation trouvé dans DataViewTroncon
                    If Len(Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(4).Value) = 0 And Left(Tb_TXT(I), 4) = "#B01" Then
                    '       --> on enregistre la 1er ligne #B01
                    Fichier_a_revoir(Revoir) = Tb_TXT(I) : Revoir += 1 : ReDim Preserve Fichier_a_revoir(Revoir)
                    '       --> on enregistre toutes les lignes suivante jusqu'a "#Z" ou null ou fin du tableau Tb_TXT
                    Do
                        I += 1
                        '       --> on remplace les id_regard txt par les ID regard si trouve ou on garde le Num regard du TXT et on enregistre
                        '   Rg_01
                        Dim Num_New As String = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(1).Value
                        If Len(Num_New) > 1 Then
                            For J = 0 To Fm_01.DataGridView1.Rows.Count
                                If Fm_01.DataGridView1.Rows(J).Cells(2).Value = Num_New Then
                                    Tb_TXT(I) = Replace(Tb_TXT(I), Fm_01.DataGridView1.Rows(J).Cells(0).Value, Num_New)
                                    Exit For
                                End If
                            Next
                        End If

                        '   Rg_02
                        Num_New = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(3).Value
                        If Len(Num_New) > 1 Then
                            For J = 0 To Fm_01.DataGridView1.Rows.Count
                                If Fm_01.DataGridView1.Rows(J).Cells(2).Value = Num_New Then
                                    Tb_TXT(I) = Replace(Tb_TXT(I), Fm_01.DataGridView1.Rows(J).Cells(0).Value, Num_New)
                                    Exit For
                                End If
                            Next
                        End If
                        Fichier_a_revoir(Revoir) = Tb_TXT(I) : Revoir += 1 : ReDim Preserve Fichier_a_revoir(Revoir)
                    Loop Until Left(Tb_TXT(I), 2) = "#Z" Or Tb_TXT(I) = "" Or I = UBound(Tb_TXT)
                End If
            End If
        Next

        ' Ferme les new_TXT

        Dim New_TxT_Attente As New IO.StreamWriter(CStr(Nom_Repertoire_Courant_Attente & "\" & Fm_01.Text_Nom_ITV.Text & ".txt"))
        Dim New_TxT_Incorpo As New IO.StreamWriter(CStr(Nom_Repertoire_Courant_Validation & "\" & Fm_01.Text_Nom_ITV.Text & ".txt"))
        For I = 0 To UBound(Fichier_ok)
            New_TxT_Incorpo.WriteLine(Fichier_ok(I))
        Next
        For I = 0 To UBound(Fichier_a_revoir)
            New_TxT_Attente.WriteLine(Fichier_a_revoir(I))
        Next
        New_TxT_Attente.Close() : New_TxT_Incorpo.Close()

    End Sub


    Public Sub Mod_Validation()

        Dim Fichier_ok(0)
        Dim Ok As Integer = 0
        Dim Nb_Troncon As Double
        Nb_Troncon = -1
        For I = 0 To UBound(Tb_TXT)
            ' --> pour les premières lignes avant le 1er troncon dans les deux fichiers
            If Left(Tb_TXT(I), 4) <> "#B01" And Nb_Troncon = -1 Then
                Fichier_ok(Ok) = Tb_TXT(I) : Ok += 1 : ReDim Preserve Fichier_ok(Ok)
            End If
            ' --> sur ligne troncon (#B01)
            If Left(Tb_TXT(I), 4) = "#B01" Then Nb_Troncon += 1

            If Nb_Troncon > -1 Then
                '   --> si le troncon a un ID canalisation trouvé dans DataViewTroncon
                If Len(Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(4).Value) > 1 And Left(Tb_TXT(I), 4) = "#B01" Then
                    '   --> Ajout ABH ABO (Nom inspecteur, Nom ITV  -->  SIBA ou Eloa, Nom de fichier)
                    Tb_TXT(I) = Tb_TXT(I) & ";ABH;ABN"
                    '       --> on enregistre la 1er ligne #B01
                    Fichier_ok(Ok) = Tb_TXT(I) : Ok += 1 : ReDim Preserve Fichier_ok(Ok)
                    '   -> On passe à la ligne suivante pour saisir ABHn ABO
                    Tb_TXT(I + 1) = Tb_TXT(I + 1) & ";""" & Fm_01.T_Type_ITV.SelectedItem & """;""" & Fm_01.Text_Nom_ITV.Text & """"
                    '   -->  Vérification de la commune
                    If New_commune = "" Then
                        New_commune = Rech_Commune(Tb_TXT(I), Tb_TXT(I + 1))
                    End If
                    Tb_TXT(I + 1) = Replace(Tb_TXT(I + 1), Old_commune, New_commune)
                    '       --> on enregistre toutes les lignes suivante jusqu' "#Z" ou null ou fin du tableau Tb_TXT  
                    Do
                        I += 1
                        '       --> on remplace les id_regard txt par les ID Géo et on enregistre
                        '   Rg_01
                        Dim Num_New As String = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(1).Value
                        If Len(Num_New) > 1 Then
                            For J = 0 To Fm_01.DataGridView1.Rows.Count
                                If Fm_01.DataGridView1.Rows(J).Cells(2).Value = Num_New Then
                                    Tb_TXT(I) = Replace(Tb_TXT(I), Fm_01.DataGridView1.Rows(J).Cells(0).Value, Fm_01.DataGridView1.Rows(J).Cells(1).Value)
                                    Exit For
                                End If
                            Next
                        End If
                        '   Rg_02
                        Num_New = Fm_01.DataViewTronco.Rows(Nb_Troncon).Cells(3).Value
                        If Len(Num_New) > 1 Then
                            For J = 0 To Fm_01.DataGridView1.Rows.Count
                                If Fm_01.DataGridView1.Rows(J).Cells(2).Value = Num_New Then
                                    Tb_TXT(I) = Replace(Tb_TXT(I), Fm_01.DataGridView1.Rows(J).Cells(0).Value, Fm_01.DataGridView1.Rows(J).Cells(1).Value)
                                    Exit For
                                End If
                            Next
                        End If
                        Fichier_ok(Ok) = Tb_TXT(I) : Ok += 1 : ReDim Preserve Fichier_ok(Ok)
                    Loop Until Left(Tb_TXT(I), 2) = "#Z" Or Tb_TXT(I) = "" Or I = UBound(Tb_TXT)
                End If

            End If
        Next

        ' Ferme les new_TXT
        Dim New_TxT_Incorpo As New IO.StreamWriter(CStr(Nom_Repertoire_Courant_Validation & "\" & Fm_01.Text_Nom_ITV.Text & ".txt"))
        For I = 0 To UBound(Fichier_ok)
            New_TxT_Incorpo.WriteLine(Fichier_ok(I))
        Next
        New_TxT_Incorpo.Close()


    End Sub

    Public Function Rech_Commune(Ligne01, Ligne02)
        Dim Nom(9) : Nom(0) = "ANDERNOS LES BAINS" : Nom(1) = "ARCACHON" : Nom(2) = "ARES" : Nom(3) = "AUDENGE" : Nom(4) = "BIGANOS"
        Nom(5) = "GUJAN MESTRAS" : Nom(6) = "LANTON" : Nom(7) = "LEGE CAP FERRET" : Nom(8) = "LE TEICH" : Nom(9) = "LA TESTE DE BUCH"
        Ligne01 = Replace(Ligne01, """", "") : Ligne01 = Replace(Ligne01, "'", " ") : Ligne01 = Replace(Ligne01, ",", " ")
        Ligne02 = Replace(Ligne02, """", "") : Ligne02 = Replace(Ligne02, "'", " ") : Ligne02 = Replace(Ligne02, ",", " ")
        ' Boucle pour Récupérer les numméro de regard -- AAD Ref regard 1  -- AAF Ref regard 2
        Ligne01 = Right(Ligne01, Len(Ligne01) - 5)
        Dim Li_01() : Li_01 = Split(Ligne01, ";") : Dim Li_02() : Li_02 = Split(Ligne02, ";")
        '   -> Boucle sur la ligne
        For Q = 0 To UBound(Li_01)
            If Li_01(Q) = "AAN" Then Old_commune = Li_02(Q) : Exit For
        Next
        For Q = 0 To UBound(Nom)
            If Nom(Q) = UCase(Old_commune) Then
                New_commune = Nom(Q)
                Exit For
            End If
        Next
        If New_commune = "" Then
            New_commune = InputBox("Saisir une commune", vbOKCancel)

        End If
        Rech_Commune = New_commune
    End Function

End Module
