Module Modif_Tb_TXT

    Public Sub Modif_ITV_fusion_Suppression(Valid)
        If Valid = 1 Then Fusion_de_deux_troncons()
        If Valid = 2 Then Suppression_du_troncon()
        Fm_01.Bt_Fusion_Tr.Visible = False
        Fm_01.Bt_Supp_Troncon.Visible = False
        MaJ_BT_Validations()  ' --> Mod Rech_ID
    End Sub

    Public Sub Fusion_de_deux_troncons()
        Dim Num_Tr_1_a_fusionner As Integer
        '   Recherche le numéro du troncon 1 à fusionner
        For I = 0 To Fm_01.DataViewTronco.Rows.Count - 1
            If Fm_01.DataViewTronco.Rows(I).Cells(6).Value = True Then Num_Tr_1_a_fusionner = I + 1 : Exit For
        Next

        ' Boucle sur Tb_TXT pour selectionner le troncon 1 à fusionner
        Dim Num_Li_Tb_TXT As Integer : Dim Ligne_Debut As Integer
        For I = 0 To UBound(Tb_TXT)
            If Left(Tb_TXT(I), 4) = "#B01" Then
                Num_Li_Tb_TXT += 1
                If Num_Li_Tb_TXT = Num_Tr_1_a_fusionner Then Ligne_Debut = I : Exit For
            End If
        Next

        Dim Tb_Txt_bis(0)   ' Copie Tb pour action
        Dim J As Integer = 0
        Dim Fin_Action As Integer = 0
        Dim Old_Lg_Tr As String = "" '= 0.0
        '   Boucle pour remplir le New Tb_Txt_Bis
        For I = 0 To UBound(Tb_TXT)
            If I + 1 > UBound(Tb_TXT) Then Exit For
            '   Pour ce qui est avant la 1er ligne selectionné
            If I < Ligne_Debut Then Tb_Txt_bis(J) = Tb_TXT(I) : J += 1 : ReDim Preserve Tb_Txt_bis(J)
            '   Quand on tombe sur la 1er ligne su troncon à fusionner
            If I = Ligne_Debut Then
                ' Remplace le Rg_02 du troncon par le Rg_02 du troncon suivant (donnée prise dans DtataViewTroncon
                Dim Old_Rg As String = Fm_01.DataViewTronco.Rows(Num_Tr_1_a_fusionner - 1).Cells(3).Value
                Dim New_Rg As String = Fm_01.DataViewTronco.Rows(Num_Tr_1_a_fusionner).Cells(3).Value
                Tb_Txt_bis(J) = Replace(Tb_TXT(I), Old_Rg, New_Rg)
                J += 1 : ReDim Preserve Tb_Txt_bis(J)
            End If
            '   Ligne suivantes jusqu'a fin du 1er troncon à fusionneer
            If I > Ligne_Debut And Fin_Action = 0 Then
                '   Si on arrive à la fin du 1er troncon "#Z"
                If Left(Tb_TXT(I + 1), 2) = "#Z" Then  ' On recherche le Z sur la ligne suivant
                    '   On Récupère le LG du troncon
                    Old_Lg_Tr = Left(Tb_TXT(I), InStr(Tb_TXT(I), ";") - 1)
                    I += 10 : Fin_Action = 1
                End If
                '   sinon on continue
            Else
                Tb_Txt_bis(J) = Tb_TXT(I) : J += 1 : ReDim Preserve Tb_Txt_bis(J)
            End If
            '   Ligne du second tronçons à fusionner pour recalcul des LG des anomalies
            If I > Ligne_Debut And Fin_Action = 1 Then
                ' Si on n'est pas à la fin du second troncon
                If Left(Tb_TXT(I + 1), 2) <> "#Z" Then
                    ' On recalcule le new Lg de l'anomalie
                    Dim New_Lg = Replace(Replace(Left(Tb_TXT(I), InStr(Tb_TXT(I), ";") - 1), ".", ",") + CDbl(Replace(Old_Lg_Tr, ".", ",")), ",", ".")
                    Dim New_ligne = New_Lg & Tb_TXT(I).substring(InStr(Tb_TXT(I), ";") - 1)
                    Tb_Txt_bis(J) = New_ligne : J += 1 : ReDim Preserve Tb_Txt_bis(J)
                Else
                    ' On prend le Z et on valide la fin de l'action
                    Tb_Txt_bis(J) = Tb_TXT(I) : J += 1 : ReDim Preserve Tb_Txt_bis(J)
                    Fin_Action = 2
                End If
            End If
            '    Pour la fin du tableau
            If I > Ligne_Debut And Fin_Action = 2 Then Tb_Txt_bis(J) = Tb_TXT(I) : J += 1 : ReDim Preserve Tb_Txt_bis(J)
        Next

        '   -->  Reprise du tableau Tb_Txt
        ReDim Tb_TXT(UBound(Tb_Txt_bis))
        For I = 0 To UBound(Tb_Txt_bis)
            Tb_TXT(I) = Tb_Txt_bis(I)
        Next

        '   --> Met à jour le DataViewTroncon
        For I = 0 To Fm_01.DataViewTronco.Rows.Count - 1
            If Fm_01.DataViewTronco.Rows(I).Cells(6).Value = True Then
                With Fm_01
                    .DataViewTronco.Rows(I).Cells(2).Value = .DataViewTronco.Rows(I + 1).Cells(2).Value
                    .DataViewTronco.Rows.RemoveAt(I + 1)
                End With
                Exit For
            End If
        Next
    End Sub


    Public Sub Suppression_du_troncon()
        '   Recherche dans DataViewTroncon la ligne à supprimer
        Dim Num_Tr_Supprime As Integer
        For I = 0 To Fm_01.DataViewTronco.Rows.Count - 1
            If Fm_01.DataViewTronco.Rows(I).Cells(6).Value = True Then Num_Tr_Supprime = I : Exit For
        Next

        '    Boucle sur Tb_Txt pour suppression du troncon
        Dim Tb_Txt_Bis(0) : Dim Num_Tr_Txt As Integer = 0
        Dim J As Integer = 0
        For I = 0 To UBound(Tb_TXT)
            If Left(Tb_TXT(I), 4) = "#B01" And Num_Tr_Supprime = Num_Tr_Txt Then
                ' Troncon à supprimer trouver
                Num_Tr_Txt += 1
                '   Boucle jusqu'à trouver Z# ou rien
                For Q = I To UBound(Tb_TXT)
                    If Left(Tb_TXT(Q), 2) = "#Z" Or Tb_TXT(Q) = "" Then
                        Exit For
                    Else
                        I += 1
                    End If
                Next
            Else
                Tb_Txt_Bis(J) = Tb_TXT(I) : J += 1 : ReDim Preserve Tb_Txt_Bis(J)
            End If
        Next

        '   -->  Reprise du tableau Tb_Txt
        ReDim Tb_TXT(UBound(Tb_Txt_Bis))
        For I = 0 To UBound(Tb_Txt_Bis)
            Tb_TXT(I) = Tb_Txt_Bis(I)
        Next

        '   --> Met à jour le DataViewTroncon
        For I = 0 To Fm_01.DataViewTronco.Rows.Count - 1
            If Fm_01.DataViewTronco.Rows(I).Cells(6).Value = True Then
                Fm_01.DataViewTronco.Rows.RemoveAt(I)
                Exit For
            End If
        Next
        Fm_01.Bt_Supp_Troncon.Visible = False
    End Sub

End Module
