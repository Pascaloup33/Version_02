Module Module_txt

    Public Sub Commande_Lire_fichier_txt()
        '   Liste des SUB pour lire le TXT et mise en page
        Met_TXT_dans_tableau_Tb_TXT()
        Met_Num_Regard_dans_DATA()
        Fm_01.Bt_Rech_id_regards.Enabled = True
    End Sub

    Public Sub Met_TXT_dans_tableau_Tb_TXT()
        Dim I As Integer : Dim Nb_Troncon As Integer
        Dim MonTxt As New System.IO.StreamReader(CStr(choix_fichier_complet))
        Dim Line As String
        Do
            ReDim Preserve Tb_TxT(I)
            Line = MonTxt.ReadLine() : Tb_TxT(I) = Line : I += 1
            If Left(Line, 3) = "#C=" Then Nb_Troncon += 1
        Loop Until Line Is Nothing
        MonTxt.Close()
        ReDim Preserve Tb_TXT(UBound(Tb_TXT) - 1)
        Fm_01.Label_Nb_Troncon.Text = "Nb de tronçons --> " & Nb_Troncon
    End Sub

    Public Sub Met_Num_Regard_dans_DATA()
        Cursor.Current = Cursors.WaitCursor
        '    Boucle sur le tableau Tb_TXT
        Dim Nb_Tr As Integer = 0
        For I = 0 To UBound(Tb_TXT)
            '   Si la ligne commence par "#B01"
            If Left(Tb_TXT(I), 4) = "#B01" Then
                ' Décompose la ligne 01 et 02
                Dim Ligne_01 As String = Tb_TXT(I)
                Dim Ligne_02 As String = Tb_TXT(I + 1)
                Ligne_01 = Replace(Ligne_01, """", "") : Ligne_01 = Replace(Ligne_01, "'", " ") : Ligne_01 = Replace(Ligne_01, ",", " ")
                Ligne_02 = Replace(Ligne_02, """", "") : Ligne_02 = Replace(Ligne_02, "'", " ") : Ligne_02 = Replace(Ligne_02, ",", " ")
                ' Boucle pour Récupérer les numméro de regard -- AAD Ref regard 1  -- AAF Ref regard 2
                Ligne_01 = Right(Ligne_01, Len(Ligne_01) - 5)
                Dim Li_01() : Li_01 = Split(Ligne_01, ";") : Dim Li_02() : Li_02 = Split(Ligne_02, ";")
                Dim Noeud_01 As String = "" : Dim Noeud_02 As String = "" : Dim Sens_itv As String = ""
                For Li = 0 To UBound(Li_01)
                    '   -->  Pour le dataVieww des tronçons
                    If Li_01(Li) = "AAD" Then Noeud_01 = Li_02(Li)
                    If Li_01(Li) = "AAF" Then Noeud_02 = Li_02(Li)
                    If Li_01(Li) = "AAK" Then Sens_itv = Li_02(Li)
                    '       POUR REGARD n° 01
                    If Li_01(Li) = "AAD" Or Li_01(Li) = "AAF" Then
                        If Nb_Tr = 0 Then
                            Fm_01.DataGridView1.Rows.Add(Li_02(Li))
                            Fm_01.Refresh()
                            Nb_Tr += 1
                        Else
                            '   Test si regard est dans le tableau
                            Dim Regard_Existe As Boolean = False
                            For Ii = 0 To Fm_01.DataGridView1.Rows.Count - 1
                                If Li_02(Li) = Fm_01.DataGridView1.Rows(Ii).Cells(0).Value Then Regard_Existe = True : Exit For
                            Next
                            If Regard_Existe = False Then Fm_01.DataGridView1.Rows.Add(Li_02(Li)) : Fm_01.Refresh() : Nb_Tr += 1
                        End If
                    End If
                Next
                ' Remplie le DataView des troncons
                Dim Data_troncon(5)
                If Sens_itv = "A" Then
                    Data_troncon(0) = Noeud_01 : Data_troncon(2) = Noeud_02 : Data_troncon(5) = "Direct"
                Else
                    Data_troncon(0) = Noeud_01 : Data_troncon(2) = Noeud_02 : Data_troncon(5) = "inDirect"
                End If
                Fm_01.DataViewTronco.Rows.Add(Data_troncon)
            End If
        Next
        Fm_01.Label_Nb_Regard.Text = "Nb de regards --> " & Nb_Tr
        Cursor.Current = Cursors.Default
    End Sub


End Module
