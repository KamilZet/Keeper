   M S B A M L   `   `   `  ���� \  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  3    -KeeperRichClient.Modules.Benefits.ParkingView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:KeeperRichClient.Modules.Benefits       � 	Resources  7   1KeeperRichClient.Modules.Benefits.IsPaidByEmpConv   IsPaidByEmpConv��%   &	          .���  � ColumnDefinitions �� $
��341* ��� $
��345* �.+��� $��New Parking Name:��$
��Left=�$��38��$��	45,11,0,0q�$	��Top=�$	��278��$��1��$��20(��� $
��Left=�$��36��$��	45,54,0,0q�$	��Top=�$	��278�� �� DisplayMemberPath$ ParkingName��$��1��$��20(�  SimpleComboBox#��[ ���� *AvailableParkings+ �� Mode$ OneWay=� �� SelectedItem �� *SelectedParking+$ TwoWay=��� $��New Parking Place:��$
��Left=�$��38��$��	45,95,0,0q�$	��Top=�$	��278��$��1��$��20(��� $
��Left=�$��36��$��
45,133,0,0q�$	��Top=�$	��282��$��1��$ ParkingPlaceName��$��20(�#��[ ���� *AvailableParkingPlaces+ �� *SelectedParkingPlace+$ TwoWay=��� $"��Save new parking reservation��$
��Left=�$��46��$��
45,326,0,0q�$	��Top=�$	��282��$��1��  SimpleButton#���  ���� *CallSaveParkingPlace+�� $(��"Delele current parking reservation��$
��Left=�$��46��$��
30,326,0,0q�$	��Top=�$	��300��#���  ���� *CallTakeParkingPlace+�� $
��Left=�$��36��$��	32,79,0,0q�$	��Top=�$	��299��$��2q�
���   �$��20(����� *CurrentParking.ParkingName+�� $
��Left=�$��36��$��
31,166,0,0q�$	��Top=�$	��299��$��2q�
���   �$��20(����� *&$CurrentParkingPlace.ParkingPlaceName+�� $��Current Parking Name:��$
��Left=�$��38��$��	32,36,0,0q�$	��Top=�$	��219��$��20(��� $��Current Parking Place:��$
��Left=�$��41��$��
31,120,0,0q�$	��Top=�$	��219��$��20(�(  "System.Windows.Controls.DatePicker  $
��Left=�$��39��$��
48,279,0,0q�$	��Top=�$	��153��$��1��$��20(�  $
��Left=�$��39��$��201,279,0,0q�$	��Top=�$	��144��$��1��$��20(��� -    ��Name$ cbxIsPaidByEmp��$��Is Paid By Employee?��$��1��$
��Left=�$��29��$��
49,183,0,0q�$	��Top=�$	��278��$��20(�
�������$��2q� d� 	IsChecked �� *IsPaidByEmployee+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��Is Included in Limit?��$��1��$
��Left=�$��27��$��
49,217,0,0q�$	��Top=�$	��282��$��20(� J� RenderTransformOrigin$ 0.5,0.5&�
�������$��2q� �� *IsIncludedInLimit+$ TwoWay=�$ PropertyChanged=�{��� 	 �� ElementName$	 cbxIsPaidByEmp��
 �� Path$
 	IsChecked� �� 	Converter# [  �� $��
Valid From��$��1��$
��Left=�$��30��$��
49,244,0,0q�$	��Top=�$	��152��$��16(��� $��Valid To��$��1��$
��Left=�$��30��$��201,244,0,0q�$	��Top=�$	��122��$��16(�