   M S B A M L   `   `   `  ����\  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      6    0KeeperRichClient.Modules.Benefits.HealthcareView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:KeeperRichClient.Modules.Benefits     5      6sys&clr-namespace:System;assembly=mscorlib     5      $	��402��5      $
��1083��6,     � 	Resources  5	       �� 
TargetType �� Property �� Value7   1KeeperRichClient.Modules.Benefits.IsPaidByEmpConv   IsPaidByEmpConv��%  '��       '�� H     '�� �     &	  �     �� 5
   
   " ��6   .�5      ��  � ��$ 12(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   5        5   
   6    5      .��5      � .+�5   
   �� $
��Left=�6   $	��218��6.   $��	10,46,0,0q�6;   $	��Top=�6N   $	��362��6f   ��5      �� * MedicalPacketsLinkedToEmployee+ �� Mode$ OneWay=� �� SelectedItem 5      �� *SelectedMedicalPacket+$ TwoWay=� �� View 5       �� 5!      .P�5"      �� $	��ID:��6%    �� Width$
 auto��62    �� DisplayMemberBinding 6@   �� 	 �� Path$	 ConfiguredMedicalPacketID��� 5#      $��Name:��6%   $
 auto��64    6A   �� $	 MedicalPacketName��� 5$      $��PaidByEmployee��6%    6=   �� $	 IsPayedByEmployee��� 5%      $��	ValidFrom��6%    68   �� $	 	ValidFrom�
 �� StringFormat$
 
dd-MM-yyyy��5&      5(      �� 5*   
   $��Packet Type:��6   $
��Left=�6'   $��
619,29,0,0q�6B   $	��Top=�6V   $��32��6n   $��98��6z   �� 5-   
   $��Valid From:��6   $
��Left=�6&   $��
618,92,0,0q�6A   $	��Top=�6U   $��27��6m   $��98��6y    J� RenderTransformOrigin$ 0.531,1.261&�6�   (  "System.Windows.Controls.DatePicker  5.   
   $
��Left=�6   $��619,124,0,0q�60   $	��Top=�6E   $	��146��5/   N     MyDatePicker#��[ 50         SelectedDate 5/      �� *NewMedPackValidFrom+$ TwoWay=�50      �� 53   
   $��	Valid To:��6   $
��Left=�6$   $��
785,92,0,0q�6?   $	��Top=�6S   $��27��6k   $��98��6w     54   
   $
��Left=�6   $��777,124,0,0q�60   $	��Top=�6E      Text$ Choose End Date��55      $	��146��56   D   #��[ 57       56      �� *NewMedPackValidTo+z�59      V� 5:      .~�5;      �� �� 5<      �� 5=       �� Angle$ -0.169Q�6&   T� 5>      5?      5A      �� 5C   
   -   5         ��Name$ cbxIsPaidByEmp��5C      $��Is Payed By Employee?��5D      $
��Left=�65   $��19��6P   $��620,188,0,0q�6\   $	��Top=�6q   $	��200��6�   $ 0.386,1.158&�6�   
�������$��1q�5F   (    d� 	IsChecked 5E      �� *NewMedPackPayByEmp+5F   (   �� 5H   
   $$��Is Included in Employee Limit?��6   $
��Left=�6<   $��28��6W   $��620,225,0,0q�6c   $	��Top=�6x   $	��310��6�   
�������$��1q�5K   &    5I      �� *NewMedPackInclInLimit+{�5J      ��  �� ElementName$ cbxIsPaidByEmp��$	 	IsChecked� �� 	Converter# [  5K   &   �� 5M   
   -   5         ��Name$ btnAddNewBenef��5M      $
��Left=�5N      $��386,280,0,0q�6,   $	��Top=�6A   $	��208��6Y   $��29��6e     SimpleButton#��[ 5P      ��5O      �� $	 ShowAddNewBenefControl�.��5Q      ]� $	��151��6   .+�5R      �� $`��Zpack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/AddItemIcon.png��6   $��23��6|   6�   �� 5S      $��Add New Beneficiary��6   $	��144��67   6E   5T      5U      �� 5V   
   $
��Left=�6   $��386,314,0,0q�6,   $	��Top=�6A   $	��208��6Y   $��29��6e   #��[ 5X      ��5W      �� *RemoveBenef+.��5Y      ]� .+�5Z      �� $c��]pack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/RemoveItemIcon.png��6   $��26��6   6�   �� 5[      $��Remove Beneficiary��6   $	��122��66   5\      5]      �� 5^   
   $
��Left=�6   $	��222��6.   $��
386,46,0,0q�6;   $	��Top=�6O   $	��208��6g   ��5_      �� *BeneficiariesLinkedToMedPack+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5`      �� *SelectedBeneficiary+$ TwoWay=� 5d      �� 5e      .P�5f      �� $��ID��6%    61   �� $	 BeneficiaryID��� 5g      $��
First Name��6%    69   �� $	 BeneficiaryFName��� 5h      $��	Last Name��6%    68   �� $	 BeneficiaryLName�5i      5k      �� 5m   
   $��Assigned Packets:��6   $
��Left=�6,   $��	10,10,0,0q�6G   $	��Top=�6Z   $	��134��6r   $��31��6~   �� 5o   
   $��Assigned Beneficiaries:��6   $
��Left=�62   $��
386,14,0,0q�6M   $	��Top=�6a   $��31��6y   $	��172��6�   �� 5q   
   -   5        $ btnAddNewMedPack��5q      $
��Left=�5r      $��618,280,0,0q�6,   $	��Top=�6A   $	��312��6Y   $��29��6e   #��[ 5t      ��5s      �� *AddMedPackToEmp+.��5w      ]� $	��151��6   $��19��6$   .+�5x      �� $`��Zpack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/AddItemIcon.png��6   $��23��6|   6�   �� 5y      $��Add New Medical Packet��6   $	��131��6:   $��14��6F   $��0,2,0,3q�6R   6e   5z      5{      �� 5~   
   $
��Left=�6   $��618,314,0,0q�6,   $	��Top=�6A   $	��311��6Y   $��29��6e   #��[ 5�      ��5      �� *RemoveMedPackFromEmployee+.��5�      ]� $	��151��6   .+�5�      �� $c��]pack://application:,,,/KeeperRichClient.Infrastructure;component/Resources/RemoveItemIcon.png��6   $��23��6   6�   �� 5�      $��Remove Medical Packet��6   $	��141��69   $��14��6E   6S   5�      5�      �� 5�   
   -   5         ��Name$ cbxSelectPacket��5�       �� DisplayMemberPath$ MedicalPacketName��5�       �� SelectedValuePath$ MedicalPacketID��5�      $
��Left=�5�      $��31��6.   $��
618,61,0,0q�6:   $	��Top=�6N   $	��312��6f     SimpleComboBox#��[ 5�      ��5�      �� $	 MedicalPacketTypes� �� SelectedValue 5�      �� $	 NewMedPackTypeId�$ TwoWay=�5�      5�      5�      