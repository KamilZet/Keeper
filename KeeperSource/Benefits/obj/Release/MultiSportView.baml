   M S B A M L   `   `   `  ���� \  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  6    0KeeperRichClient.Modules.Benefits.MultiSportView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:KeeperRichClient.Modules.Benefits       � 	Resources  7   1KeeperRichClient.Modules.Benefits.IsPaidByEmpConv   IsPaidByEmpConv �� 
TargetType �� Property �� Value��%<   &	        '��        �� " ��.���  � ��$ 16(�.���  � ColumnDefinitions .+��� $
��Left=�$	��293��$��	28,43,0,0q�$	��Top=�$	��274������ *MultiSportOwnerToEmployee+ �� Mode$ OneWay=� �� SelectedItem �� *SelectedMultiSportOwner+$ TwoWay=� �� View �� .P��� $��MultiSport Type�� �� DisplayMemberBinding �� *MultisportPacketTypeName+�� $��Owner First Name�� �� 	 �� Path$	 BeneficiaryFName��� $��Owner Last Name�� �� $	 BeneficiaryLName��� $��Multisport Card Type:��$
��Left=�$��27��$��
339,43,0,0q�$	��Top=�$	��273���� $
��Left=�$	��266��
 �� DisplayMemberPath$
 MultisportPacketTypeName��$��20(� �� SelectedValuePath$ MultisportPacketTypeID��$��339,75,0,313q�  SimpleComboBox#��[ ���� $	 MultiSportCardType� �� SelectedValue �� $	 MultiSportPacketTypeId�$ TwoWay=��� $��Valid From:��$
��Left=�$��32��$��339,114,0,0q�$	��Top=�$	��120��(  "System.Windows.Controls.DatePicker  $
��Left=�$��28��$��339,151,0,0q�$	��Top=�$	��128��  MyDatePicker#��[    SelectedDate �� *	ValidFrom+$ TwoWay=��� $��	Valid To:��$
��Left=�$��32��$��472,114,0,0q�$	��Top=�$��96��  $
��Left=�$��28��$��472,151,0,0q�$	��Top=�$	��133��$��16(�#��[  �� *	ValidTo+$ TwoWay=��� $6��0Multisport Card Owner: (leave empty if employee)��$
��Left=�$��32��$��339,253,0,0q�$	��Top=�$	��367���� -    ��Name$ cbxIsPaidByEmp��$��Is Paid By Employee?��$
��Left=�$��24��$��341,195,0,0q�$	��Top=�$	��271�� J� RenderTransformOrigin$ 0.386,1.158&�$��16(�
�������$��2q� d� 	IsChecked �� *IsPaidByEmployee+�� $$��Is Included in Employee Limit?��$
��Left=�$��24��$��341,224,0,0q�$	��Top=�$	��289��$��16(�
�������$��2q� �� *IsIncludedInEmployeeLimit+{���  �� ElementName$ cbxIsPaidByEmp��$	 	IsChecked� �� 	Converter# [  �� $
��Left=�$��341,290,0,0q�$	��Top=�$	��273��$��35��#��[ ���� *BeneficiariesToEmployee+$ OneWay=� �� *MultisportOwner+���� .R��� $��20(� � DataContext �� ��`�  �� StringFormat$ 	{0} - {1}��.1��� $	 BeneficiaryLName��� $	 BeneficiaryFName��� $"��Deactivate MultiSport Packet��$
��Left=�$��38��$��
28,361,0,0q�$	��Top=�$	��274��  SimpleButton#���  ���� * CallDeactivateMultiSportPacket+�� $ ��Save New MultiSport Packet��$
��Left=�$��38��$��339,361,0,0q�$	��Top=�$	��271��#���  ���� *CallSaveNewMultiSportPacket+