<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Fm_01
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bt_Quitter = New System.Windows.Forms.Button()
        Me.Bt_Restart = New System.Windows.Forms.Button()
        Me.Bt_Select_txt = New System.Windows.Forms.Button()
        Me.Text_Nom_ITV = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label_Nb_Troncon = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID_txt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_SIG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Num_regard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_Nb_Regard = New System.Windows.Forms.Label()
        Me.DataViewTronco = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_SIG_02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_Troncon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sens = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Bt_Rech_id_regards = New System.Windows.Forms.Button()
        Me.Bt_Id_Troncon = New System.Windows.Forms.Button()
        Me.Bt_Valid_Incorpo = New System.Windows.Forms.Button()
        Me.Bt_Mise_Attente = New System.Windows.Forms.Button()
        Me.Bt_Deux_Dossier = New System.Windows.Forms.Button()
        Me.Bt_Fusion_Tr = New System.Windows.Forms.Button()
        Me.Bt_Supp_Troncon = New System.Windows.Forms.Button()
        Me.T_Type_ITV = New System.Windows.Forms.CheckedListBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataViewTronco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bt_Quitter
        '
        Me.Bt_Quitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_Quitter.Location = New System.Drawing.Point(1313, 12)
        Me.Bt_Quitter.Name = "Bt_Quitter"
        Me.Bt_Quitter.Size = New System.Drawing.Size(89, 33)
        Me.Bt_Quitter.TabIndex = 0
        Me.Bt_Quitter.Text = "QUITTER"
        Me.Bt_Quitter.UseVisualStyleBackColor = True
        '
        'Bt_Restart
        '
        Me.Bt_Restart.Location = New System.Drawing.Point(1313, 51)
        Me.Bt_Restart.Name = "Bt_Restart"
        Me.Bt_Restart.Size = New System.Drawing.Size(89, 33)
        Me.Bt_Restart.TabIndex = 1
        Me.Bt_Restart.Text = "Relancer"
        Me.Bt_Restart.UseVisualStyleBackColor = True
        '
        'Bt_Select_txt
        '
        Me.Bt_Select_txt.BackColor = System.Drawing.SystemColors.Info
        Me.Bt_Select_txt.Location = New System.Drawing.Point(12, 12)
        Me.Bt_Select_txt.Name = "Bt_Select_txt"
        Me.Bt_Select_txt.Size = New System.Drawing.Size(89, 33)
        Me.Bt_Select_txt.TabIndex = 2
        Me.Bt_Select_txt.Text = "Selection TXT"
        Me.Bt_Select_txt.UseVisualStyleBackColor = False
        '
        'Text_Nom_ITV
        '
        Me.Text_Nom_ITV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Nom_ITV.Location = New System.Drawing.Point(125, 21)
        Me.Text_Nom_ITV.Name = "Text_Nom_ITV"
        Me.Text_Nom_ITV.Size = New System.Drawing.Size(100, 20)
        Me.Text_Nom_ITV.TabIndex = 3
        Me.Text_Nom_ITV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'Label_Nb_Troncon
        '
        Me.Label_Nb_Troncon.AutoSize = True
        Me.Label_Nb_Troncon.Location = New System.Drawing.Point(250, 21)
        Me.Label_Nb_Troncon.Name = "Label_Nb_Troncon"
        Me.Label_Nb_Troncon.Size = New System.Drawing.Size(78, 13)
        Me.Label_Nb_Troncon.TabIndex = 4
        Me.Label_Nb_Troncon.Text = "Nb tronçon --> "
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_txt, Me.ID_SIG, Me.Num_regard})
        Me.DataGridView1.Location = New System.Drawing.Point(29, 121)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(486, 531)
        Me.DataGridView1.TabIndex = 5
        '
        'ID_txt
        '
        Me.ID_txt.HeaderText = "ID_txt"
        Me.ID_txt.Name = "ID_txt"
        Me.ID_txt.Width = 120
        '
        'ID_SIG
        '
        Me.ID_SIG.HeaderText = "ID_SIG"
        Me.ID_SIG.Name = "ID_SIG"
        Me.ID_SIG.Width = 200
        '
        'Num_regard
        '
        Me.Num_regard.HeaderText = "Num_regard"
        Me.Num_regard.Name = "Num_regard"
        Me.Num_regard.Width = 120
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Liste des regards de l'ITV"
        '
        'Label_Nb_Regard
        '
        Me.Label_Nb_Regard.AutoSize = True
        Me.Label_Nb_Regard.Location = New System.Drawing.Point(192, 89)
        Me.Label_Nb_Regard.Name = "Label_Nb_Regard"
        Me.Label_Nb_Regard.Size = New System.Drawing.Size(87, 13)
        Me.Label_Nb_Regard.TabIndex = 7
        Me.Label_Nb_Regard.Text = "Nb de regard --> "
        '
        'DataViewTronco
        '
        Me.DataViewTronco.AllowUserToAddRows = False
        Me.DataViewTronco.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataViewTronco.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataViewTronco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataViewTronco.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.ID_SIG_02, Me.ID_Troncon, Me.Sens, Me.Valid})
        Me.DataViewTronco.Location = New System.Drawing.Point(559, 121)
        Me.DataViewTronco.Name = "DataViewTronco"
        Me.DataViewTronco.Size = New System.Drawing.Size(887, 531)
        Me.DataViewTronco.TabIndex = 8
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "R_01"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "ID_SIG_01"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "R_02"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'ID_SIG_02
        '
        Me.ID_SIG_02.HeaderText = "ID_SIG_02"
        Me.ID_SIG_02.Name = "ID_SIG_02"
        Me.ID_SIG_02.Width = 120
        '
        'ID_Troncon
        '
        Me.ID_Troncon.HeaderText = "ID_Troncon"
        Me.ID_Troncon.Name = "ID_Troncon"
        Me.ID_Troncon.Width = 200
        '
        'Sens
        '
        Me.Sens.HeaderText = "Sens"
        Me.Sens.Name = "Sens"
        '
        'Valid
        '
        Me.Valid.HeaderText = "Valid"
        Me.Valid.Name = "Valid"
        Me.Valid.Width = 50
        '
        'Bt_Rech_id_regards
        '
        Me.Bt_Rech_id_regards.BackColor = System.Drawing.Color.MistyRose
        Me.Bt_Rech_id_regards.Enabled = False
        Me.Bt_Rech_id_regards.Location = New System.Drawing.Point(331, 63)
        Me.Bt_Rech_id_regards.Name = "Bt_Rech_id_regards"
        Me.Bt_Rech_id_regards.Size = New System.Drawing.Size(131, 23)
        Me.Bt_Rech_id_regards.TabIndex = 9
        Me.Bt_Rech_id_regards.Text = "Recherche ID Regard"
        Me.Bt_Rech_id_regards.UseVisualStyleBackColor = False
        '
        'Bt_Id_Troncon
        '
        Me.Bt_Id_Troncon.BackColor = System.Drawing.Color.MistyRose
        Me.Bt_Id_Troncon.Location = New System.Drawing.Point(584, 63)
        Me.Bt_Id_Troncon.Name = "Bt_Id_Troncon"
        Me.Bt_Id_Troncon.Size = New System.Drawing.Size(172, 23)
        Me.Bt_Id_Troncon.TabIndex = 10
        Me.Bt_Id_Troncon.Text = "Recherche ID TRONCONS"
        Me.Bt_Id_Troncon.UseVisualStyleBackColor = False
        Me.Bt_Id_Troncon.Visible = False
        '
        'Bt_Valid_Incorpo
        '
        Me.Bt_Valid_Incorpo.BackColor = System.Drawing.Color.DarkSalmon
        Me.Bt_Valid_Incorpo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_Valid_Incorpo.Location = New System.Drawing.Point(1086, 33)
        Me.Bt_Valid_Incorpo.Name = "Bt_Valid_Incorpo"
        Me.Bt_Valid_Incorpo.Size = New System.Drawing.Size(167, 31)
        Me.Bt_Valid_Incorpo.TabIndex = 11
        Me.Bt_Valid_Incorpo.Text = "Validation pour incorpo"
        Me.Bt_Valid_Incorpo.UseVisualStyleBackColor = False
        Me.Bt_Valid_Incorpo.Visible = False
        '
        'Bt_Mise_Attente
        '
        Me.Bt_Mise_Attente.BackColor = System.Drawing.Color.LightCyan
        Me.Bt_Mise_Attente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_Mise_Attente.Location = New System.Drawing.Point(789, 33)
        Me.Bt_Mise_Attente.Name = "Bt_Mise_Attente"
        Me.Bt_Mise_Attente.Size = New System.Drawing.Size(136, 31)
        Me.Bt_Mise_Attente.TabIndex = 12
        Me.Bt_Mise_Attente.Text = "Mise en attente"
        Me.Bt_Mise_Attente.UseVisualStyleBackColor = False
        Me.Bt_Mise_Attente.Visible = False
        '
        'Bt_Deux_Dossier
        '
        Me.Bt_Deux_Dossier.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Bt_Deux_Dossier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_Deux_Dossier.Location = New System.Drawing.Point(931, 33)
        Me.Bt_Deux_Dossier.Name = "Bt_Deux_Dossier"
        Me.Bt_Deux_Dossier.Size = New System.Drawing.Size(149, 31)
        Me.Bt_Deux_Dossier.TabIndex = 13
        Me.Bt_Deux_Dossier.Text = "Eng dans deux dossier"
        Me.Bt_Deux_Dossier.UseVisualStyleBackColor = False
        Me.Bt_Deux_Dossier.Visible = False
        '
        'Bt_Fusion_Tr
        '
        Me.Bt_Fusion_Tr.BackColor = System.Drawing.Color.Orchid
        Me.Bt_Fusion_Tr.Location = New System.Drawing.Point(869, 85)
        Me.Bt_Fusion_Tr.Name = "Bt_Fusion_Tr"
        Me.Bt_Fusion_Tr.Size = New System.Drawing.Size(111, 26)
        Me.Bt_Fusion_Tr.TabIndex = 14
        Me.Bt_Fusion_Tr.Text = "Fusionner tronçons"
        Me.Bt_Fusion_Tr.UseVisualStyleBackColor = False
        Me.Bt_Fusion_Tr.Visible = False
        '
        'Bt_Supp_Troncon
        '
        Me.Bt_Supp_Troncon.BackColor = System.Drawing.Color.Purple
        Me.Bt_Supp_Troncon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_Supp_Troncon.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Bt_Supp_Troncon.Location = New System.Drawing.Point(1002, 85)
        Me.Bt_Supp_Troncon.Name = "Bt_Supp_Troncon"
        Me.Bt_Supp_Troncon.Size = New System.Drawing.Size(135, 26)
        Me.Bt_Supp_Troncon.TabIndex = 15
        Me.Bt_Supp_Troncon.Text = "Supprimer tronçon"
        Me.Bt_Supp_Troncon.UseVisualStyleBackColor = False
        Me.Bt_Supp_Troncon.Visible = False
        '
        'T_Type_ITV
        '
        Me.T_Type_ITV.CheckOnClick = True
        Me.T_Type_ITV.FormattingEnabled = True
        Me.T_Type_ITV.Items.AddRange(New Object() {"SIBA", "ELOA", "MAIRIE", "AUTRE"})
        Me.T_Type_ITV.Location = New System.Drawing.Point(489, 14)
        Me.T_Type_ITV.Name = "T_Type_ITV"
        Me.T_Type_ITV.Size = New System.Drawing.Size(79, 79)
        Me.T_Type_ITV.TabIndex = 16
        '
        'Fm_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1500, 687)
        Me.Controls.Add(Me.T_Type_ITV)
        Me.Controls.Add(Me.Bt_Supp_Troncon)
        Me.Controls.Add(Me.Bt_Fusion_Tr)
        Me.Controls.Add(Me.Bt_Deux_Dossier)
        Me.Controls.Add(Me.Bt_Mise_Attente)
        Me.Controls.Add(Me.Bt_Valid_Incorpo)
        Me.Controls.Add(Me.Bt_Id_Troncon)
        Me.Controls.Add(Me.Bt_Rech_id_regards)
        Me.Controls.Add(Me.DataViewTronco)
        Me.Controls.Add(Me.Label_Nb_Regard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label_Nb_Troncon)
        Me.Controls.Add(Me.Text_Nom_ITV)
        Me.Controls.Add(Me.Bt_Select_txt)
        Me.Controls.Add(Me.Bt_Restart)
        Me.Controls.Add(Me.Bt_Quitter)
        Me.Name = "Fm_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des txt ITV pour Géo"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataViewTronco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Bt_Quitter As Button
    Friend WithEvents Bt_Restart As Button
    Friend WithEvents Bt_Select_txt As Button
    Friend WithEvents Text_Nom_ITV As TextBox
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents Label_Nb_Troncon As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ID_txt As DataGridViewTextBoxColumn
    Friend WithEvents ID_SIG As DataGridViewTextBoxColumn
    Friend WithEvents Num_regard As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label_Nb_Regard As Label
    Friend WithEvents DataViewTronco As DataGridView
    Friend WithEvents Bt_Rech_id_regards As Button
    Friend WithEvents Bt_Id_Troncon As Button
    Friend WithEvents Bt_Valid_Incorpo As Button
    Friend WithEvents Bt_Mise_Attente As Button
    Friend WithEvents Bt_Deux_Dossier As Button
    Friend WithEvents Bt_Fusion_Tr As Button
    Friend WithEvents Bt_Supp_Troncon As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents ID_SIG_02 As DataGridViewTextBoxColumn
    Friend WithEvents ID_Troncon As DataGridViewTextBoxColumn
    Friend WithEvents Sens As DataGridViewTextBoxColumn
    Friend WithEvents Valid As DataGridViewCheckBoxColumn
    Friend WithEvents T_Type_ITV As CheckedListBox
End Class
