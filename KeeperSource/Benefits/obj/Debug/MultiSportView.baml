   M S B A M L   `   `   `  ����\  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  5      6    0KeeperRichClient.Modules.Benefits.MultiSportView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:KeeperRichClient.Modules.Benefits     5        � 	Resources  5
      7   1KeeperRichClient.Modules.Benefits.IsPaidByEmpConv   IsPaidByEmpConv �� 
TargetType �� Property �� Value��%o   &	        '��        5   
   6    �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   5      5      .��5      �  � ColumnDefinitions 5   
   .+�5   
   �� $
��Left=�6   $	��293��6.   $��	28,43,0,0q�6;   $	��Top=�6N   $	��274��6f   ��5      �� *MultiSportOwnerToEmployee+ �� Mode$ OneWay=� �� SelectedItem 5      �� *SelectedMultiSportOwner+$ TwoWay=� �� View 5      �� 5      .P�5      �� $��MultiSport Type��6%    �� DisplayMemberBinding 6>   �� *MultisportPacketTypeName+�� 5      $��Owner First Name��6%    6?   �� 	 �� Path$	 BeneficiaryFName��� 5      $��Owner Last Name��6%    6>   �� $	 BeneficiaryLName�5      5      �� 5!   
   $��Multisport Card Type:��6   $
��Left=�60   $��27��6K   $��
339,43,0,0q�6W   $	��Top=�6k   $	��273��6�   �� 5#   
   $
��Left=�6   $	��266��6.   
 �� DisplayMemberPath$
 MultisportPacketTypeName��5%      $��20(�6@    �� SelectedValuePath$ MultisportPacketTypeID��5&      $��339,75,0,313q�5'   U     SimpleComboBox#��[ 5(      ��5$      �� $	 MultiSportCardType� �� SelectedValue 5'      �� $	 MultiSportPacketTypeId�$ TwoWay=�5*      �� 5,   
   $��Valid From:��6   $
��Left=�6&   $��32��6A   $��339,114,0,0q�6M   $	��Top=�6b   $	��120��6z   (  "System.Windows.Controls.DatePicker  5-   
   $
��Left=�6   $��28��60   $��339,151,0,0q�6<   $	��Top=�6Q   $	��128��6i     MyDatePicker#��[ 5/         SelectedDate 5.      �� *	ValidFrom+$ TwoWay=�5/      �� 52   
   $��	Valid To:��6   $
��Left=�6$   $��32��6?   $��472,114,0,0q�6K   $	��Top=�6`   $��96��6x     53   
   $
��Left=�6   $��28��60   $��472,151,0,0q�6<   $	��Top=�6Q   $	��133��6i   $��16(�54      #��[ 56       55      �� *	ValidTo+$ TwoWay=�56      �� 59   
   $6��0Multisport Card Owner: (leave empty if employee)��6   $
��Left=�6K   $��32��6f   $��339,253,0,0q�6r   $	��Top=�6�   $	��367��6�   �� 5:   
   -   5         ��Name$ cbxIsPaidByEmp��5:      $��Is Paid By Employee?��5;      $
��Left=�6,   $��24��6G   $��341,195,0,0q�6S   $	��Top=�6h   $	��271��6�    J� RenderTransformOrigin$ 0.386,1.158&�6�   $��16(�5<      
�������$��2q�5>       d� 	IsChecked 5=   
   �� *IsPaidByEmployee+5>      �� 5A   
   $$��Is Included in Employee Limit?��6   $
��Left=�6<   $��24��6W   $��341,224,0,0q�6c   $	��Top=�6x   $	��289��6�   $��16(�5B      
�������$��2q�5E   !    5C      �� *IsIncludedInEmployeeLimit+{�5D      ��  �� ElementName$ cbxIsPaidByEmp��$	 	IsChecked� �� 	Converter# [  5E   !   �� 5G   
   $
��Left=�6   $��341,290,0,0q�6.   $	��Top=�6C   $	��273��6[   $��35��6g   #��[ 5J      ��5H      �� *BeneficiariesToEmployee+$ OneWay=� 5I      �� *MultisportOwner+��5L      �� 5M      .R�5N      �� $��20(�68    � DataContext 6    �� ��5O      `� 5P       �� StringFormat$ 	{0} - {1}��6+   .1�5Q   "   �� $	 BeneficiaryLName�6*   �� 5R   "   $	 BeneficiaryFName�6*   5S      5U      5V      5X      �� 5Y   
   $"��Deactivate MultiSport Packet��6   $
��Left=�68   $��38��6S   $��
28,361,0,0q�6_   $	��Top=�6s   $	��274��6�     SimpleButton#���  5Z      ��5[      �� * CallDeactivateMultiSportPacket+�� 5]   
   $ ��Save New MultiSport Packet��6   $
��Left=�66   $��38��6Q   $��339,361,0,0q�6]   $	��Top=�6r   $	��271��6�   #���  5^      ��5_      �� *CallSaveNewMultiSportPacket+5d      5e      