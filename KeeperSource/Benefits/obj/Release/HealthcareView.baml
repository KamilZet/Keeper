   M S B A M L   `   `   `  ���� \  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6    0KeeperRichClient.Modules.Benefits.HealthcareView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:KeeperRichClient.Modules.Benefits     6sys&clr-namespace:System;assembly=mscorlib     $	��402��$
��1083��  � 	Resources   �� 
TargetType �� Property �� Value7   1KeeperRichClient.Modules.Benefits.IsPaidByEmpConv   IsPaidByEmpConv��%�   '��       '�� #     '�� F     &	  i     �� " ��.���  � ��$ 12(��� " ��.���  � ��$ 16(��� " ��.���  � ��$ 16(�  .��� .+��� $
��Left=�$	��218��$��	10,46,0,0q�$	��Top=�$	��362������ * MedicalPacketsLinkedToEmployee+ �� Mode$ OneWay=� �� SelectedItem �� *SelectedMedicalPacket+$ TwoWay=� �� View �� .P��� $	��ID:�� �� Width$
 auto�� �� DisplayMemberBinding �� 	 �� Path$	 ConfiguredMedicalPacketID��� $��Name:��$
 auto�� �� $	 MedicalPacketName��� $��PaidByEmployee�� �� $	 IsPayedByEmployee��� $��	ValidFrom�� �� $	 	ValidFrom�
 �� StringFormat$
 
dd-MM-yyyy���� $��Packet Type:��$
��Left=�$��
619,29,0,0q�$	��Top=�$��32��$��98���� $��Valid From:��$
��Left=�$��
618,92,0,0q�$	��Top=�$��27��$��98�� J� RenderTransformOrigin$ 0.531,1.261&�(  "System.Windows.Controls.DatePicker  $
��Left=�$��619,124,0,0q�$	��Top=�$	��146��  MyDatePicker#��[    SelectedDate �� *NewMedPackValidFrom+$ TwoWay=��� $��	Valid To:��$
��Left=�$��
785,92,0,0q�$	��Top=�$��27��$��98��  $
��Left=�$��777,124,0,0q�$	��Top=�   Text$ Choose End Date��$	��146��#��[  �� *NewMedPackValidTo+z�V� .~��� �� ��  �� Angle$ -0.169Q�T� �� -    ��Name$ cbxIsPaidByEmp��$��Is Payed By Employee?��$
��Left=�$��19��$��620,188,0,0q�$	��Top=�$	��200��$ 0.386,1.158&�
�������$��1q� d� 	IsChecked �� *NewMedPackPayByEmp+�� $$��Is Included in Employee Limit?��$
��Left=�$��28��$��620,225,0,0q�$	��Top=�$	��310��
�������$��1q� �� *NewMedPackInclInLimit+{���  �� ElementName$ cbxIsPaidByEmp��$	 	IsChecked� �� 	Converter# [  �� -    ��Name$ btnAddNewBenef��$
��Left=�$��386,280,0,0q�$	��Top=�$	��208��$��29��  SimpleButton#��[ ���� $	 ShowAddNewBenefControl�.��]� $	��151��.+��� $`��Zpack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/AddItemIcon.png��$��23���� $��Add New Beneficiary��$	��144���� $
��Left=�$��386,314,0,0q�$	��Top=�$	��208��$��29��#��[ ���� *RemoveBenef+.��]� .+��� $c��]pack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/RemoveItemIcon.png��$��26���� $��Remove Beneficiary��$	��122���� $
��Left=�$	��222��$��
386,46,0,0q�$	��Top=�$	��208������ *BeneficiariesLinkedToMedPack+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� *SelectedBeneficiary+$ TwoWay=� �� .P��� $��ID�� �� $	 BeneficiaryID��� $��
First Name�� �� $	 BeneficiaryFName��� $��	Last Name�� �� $	 BeneficiaryLName��� $��Assigned Packets:��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��134��$��31���� $��Assigned Beneficiaries:��$
��Left=�$��
386,14,0,0q�$	��Top=�$��31��$	��172���� -   $ btnAddNewMedPack��$
��Left=�$��618,280,0,0q�$	��Top=�$	��312��$��29��#��[ ���� *AddMedPackToEmp+.��]� $	��151��$��19��.+��� $`��Zpack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/AddItemIcon.png��$��23���� $��Add New Medical Packet��$	��131��$��14��$��0,2,0,3q��� $
��Left=�$��618,314,0,0q�$	��Top=�$	��311��$��29��#��[ ���� *RemoveMedPackFromEmployee+.��]� $	��151��.+��� $c��]pack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/RemoveItemIcon.png��$��23���� $��Remove Medical Packet��$	��141��$��14���� -    ��Name$ cbxSelectPacket�� �� DisplayMemberPath$ MedicalPacketName�� �� SelectedValuePath$ MedicalPacketID��$
��Left=�$��31��$��
618,61,0,0q�$	��Top=�$	��312��  SimpleComboBox#��[ ���� $	 MedicalPacketTypes� �� SelectedValue �� $	 NewMedPackTypeId�$ TwoWay=�