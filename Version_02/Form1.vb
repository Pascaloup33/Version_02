Public Class Fm_01
    Private Sub Bt_Quitter_Click(sender As Object, e As EventArgs) Handles Bt_Quitter.Click
        Application.Exit()
    End Sub

    Private Sub Bt_Restart_Click(sender As Object, e As EventArgs) Handles Bt_Restart.Click
        Application.Restart()
    End Sub

    Private Sub Bt_Select_txt_Click(sender As Object, e As EventArgs) Handles Bt_Select_txt.Click
        ' Choix du fichier TXT
        With OpenFileDialog
            .InitialDirectory = Chemin_lecteur
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Nom_Fichier_txt = .SafeFileName ' nom du fichier TXT
                choix_fichier_complet = .FileName   ' Chemin complet avec fichier
                Repertoire_fichier = Replace(choix_fichier_complet, Nom_Fichier_txt, "")        ' Répertoire selectionner
            End If
            If Len(Repertoire_fichier) = 0 Then Application.Restart()
            Me.Text_Nom_ITV.Text = Nom_Fichier_txt.Substring(0, Len(Nom_Fichier_txt) - 4) : Refresh()
            Commande_Lire_fichier_txt()    '   --> Module TXT
        End With
    End Sub

    Private Sub Bt_Rech_id_regards_Click(sender As Object, e As EventArgs) Handles Bt_Rech_id_regards.Click
        Commande_Rech_ID    '   Module Rech_Id
    End Sub

    Private Sub Bt_Id_Troncon_Click(sender As Object, e As EventArgs) Handles Bt_Id_Troncon.Click
        Commande_Rech_Canalisation  '   ->> Mod Rech_ID
    End Sub

    Private Sub Sub_Fusion_Suppre(sender As Object, e As DataGridViewCellEventArgs) Handles DataViewTronco.CellContentClick

        Dim Nb_Tr_Choisi As Integer = 0
        Me.Bt_Supp_Troncon.Visible = False : Me.Bt_Fusion_Tr.Visible = False

        For I = 0 To Me.DataViewTronco.Rows.Count - 1
            If Me.DataViewTronco.Rows(I).Cells(6).Value = True Then Nb_Tr_Choisi += 1
        Next
        If Nb_Tr_Choisi = 1 Then Me.Bt_Supp_Troncon.Visible = True
        If Nb_Tr_Choisi = 2 Then Me.Bt_Fusion_Tr.Visible = True
    End Sub

    Private Sub Bt_Fusion_Tr_Click(sender As Object, e As EventArgs) Handles Bt_Fusion_Tr.Click
        Modif_ITV_fusion_Suppression(1) '   Mod Rech_ID
    End Sub

    Private Sub Bt_Supp_Troncon_Click(sender As Object, e As EventArgs) Handles Bt_Supp_Troncon.Click
        Modif_ITV_fusion_Suppression(2) '   Mod Rech_ID
    End Sub

    Private Sub Bt_Mise_Attente_Click(sender As Object, e As EventArgs) Handles Bt_Mise_Attente.Click
        Type_Enregistrement(1)
    End Sub

    Private Sub Bt_Deux_Dossier_Click(sender As Object, e As EventArgs) Handles Bt_Deux_Dossier.Click
        Type_Enregistrement(2)
    End Sub

    Private Sub Bt_Valid_Incorpo_Click(sender As Object, e As EventArgs) Handles Bt_Valid_Incorpo.Click
        Type_Enregistrement(3)
    End Sub
End Class
