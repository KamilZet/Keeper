   M S B A M L   `   `   `  ����\  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  5      3    -KeeperRichClient.Modules.Benefits.ParkingView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:KeeperRichClient.Modules.Benefits     5        � 	Resources  5
      7   1KeeperRichClient.Modules.Benefits.IsPaidByEmpConv   IsPaidByEmpConv��%   &	          5   
   6    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��341* �6   �� 5      $
��345* �6   .+�5   
   �� $��New Parking Name:��6   $
��Left=�6,   $��38��6G   $��	45,11,0,0q�6S   $	��Top=�6f   $	��278��6~   $��1��6�   $��20(�5      �� 5   
   $
��Left=�6   $��36��6.   $��	45,54,0,0q�6:   $	��Top=�6M   $	��278��6e    �� DisplayMemberPath$ ParkingName��5      $��1��5   H   $��20(�5        SimpleComboBox#��[ 5      ��5      �� *AvailableParkings+ �� Mode$ OneWay=� �� SelectedItem 5      �� *SelectedParking+$ TwoWay=�5      �� 5   
   $��New Parking Place:��6   $
��Left=�6-   $��38��6H   $��	45,95,0,0q�6T   $	��Top=�6g   $	��278��6   $��1��6�   $��20(�5      �� 5    
   $
��Left=�6   $��36��6.   $��
45,133,0,0q�6:   $	��Top=�6N   $	��282��6f   $��1��6r   $ ParkingPlaceName��5"      $��20(�5$      #��[ 5%      ��5!      �� *AvailableParkingPlaces+ 5#      �� *SelectedParkingPlace+$ TwoWay=�5%      �� 5'   
   $"��Save new parking reservation��6   $
��Left=�68   $��46��6S   $��
45,326,0,0q�6_   $	��Top=�6s   $	��282��6�   $��1��6�     SimpleButton#���  5)      ��5(      �� *CallSaveParkingPlace+5)      �� 5+   
   $(��"Delele current parking reservation��6   $
��Left=�6>   $��46��6Y   $��
30,326,0,0q�6e   $	��Top=�6y   $	��300��6�   #���  5-      ��5,      �� *CallTakeParkingPlace+5-      �� 5/   
   $
��Left=�6   $��36��6+   $��	32,79,0,0q�67   $	��Top=�6J   $	��299��6b   $��2q�6n   
���   �$��20(�51      ��50      �� *CurrentParking.ParkingName+51      �� 53   
   $
��Left=�6   $��36��6+   $��
31,166,0,0q�67   $	��Top=�6K   $	��299��6c   $��2q�6o   
���   �$��20(�55      ��54      �� *&$CurrentParkingPlace.ParkingPlaceName+55      �� 57   
   $��Current Parking Name:��6   $
��Left=�60   $��38��6K   $��	32,36,0,0q�6W   $	��Top=�6j   $	��219��6�   $��20(�58      �� 5:   
   $��Current Parking Place:��6   $
��Left=�61   $��41��6L   $��
31,120,0,0q�6X   $	��Top=�6l   $	��219��6�   $��20(�5;      (  "System.Windows.Controls.DatePicker  5=   
   $
��Left=�6   $��39��60   $��
48,279,0,0q�6<   $	��Top=�6P   $	��153��6h   $��1��6t   $��20(�5>        5@   
   $
��Left=�6   $��39��60   $��201,279,0,0q�6<   $	��Top=�6Q   $	��144��6i   $��1��6u   $��20(�5A      �� 5C   
   -   5         ��Name$ cbxIsPaidByEmp��5C      $��Is Paid By Employee?��5D      $��1��60   $
��Left=�6@   $��29��6[   $��
49,183,0,0q�6g   $	��Top=�6{   $	��278��6�   $��20(�5F      
�������$��2q�5G   &    d� 	IsChecked 5E      �� *IsPaidByEmployee+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5G   &   �� 5H   
   $��Is Included in Limit?��6   $��1��63   $
��Left=�6C   $��27��6^   $��
49,217,0,0q�6j   $	��Top=�6~   $	��282��6�   $��20(�5K       J� RenderTransformOrigin$ 0.5,0.5&�6!   
�������$��2q�5L   &    5I      �� *IsIncludedInLimit+$ TwoWay=�$ PropertyChanged=�{�5J      �� 	 �� ElementName$	 cbxIsPaidByEmp��
 �� Path$
 	IsChecked� �� 	Converter# [  5L   &   �� 5M   
   $��
Valid From��6   $��1��6%   $
��Left=�65   $��30��6P   $��
49,244,0,0q�6\   $	��Top=�6p   $	��152��6�   $��16(�5N      �� 5O   
   $��Valid To��6   $��1��6#   $
��Left=�63   $��30��6N   $��201,244,0,0q�6Z   $	��Top=�6o   $	��122��6�   $��16(�5P      5U      5V      