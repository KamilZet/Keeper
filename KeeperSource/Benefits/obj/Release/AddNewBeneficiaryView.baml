   M S B A M L   `   `   `  ���� \  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem =    7KeeperRichClient.Modules.Benefits.AddNewBeneficiaryView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dbenefits/clr-namespace:KeeperRichClient.Modules.Benefits     6sys&clr-namespace:System;assembly=mscorlib        WindowBrush#��[  $	��532��$	��499��  � 	Resources   �� 
TargetType �� Property �� Value��%�   '��       '�� Q     �� " ��.���  � ��$ 80����  � ��$ 1����  � ��$ Right=��� " ��.���  � ��$	 283����  � ��$ 1����  � ��$
 Left=�.���  � ColumnDefinitions .+��� $��10q�.+��� $��Beneficiary Personal Data��$��Center=�$��12,20,11,20q�$��18(�$��	ExtraBold"�$	��260��$��36���� $��Center=�$��29��$	��281��  SimpleComboBox#��[ $��
85,0,105,0q����� *GetBeneficiaries+ �� SelectedItem �� *Beneficiary+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R��� $��20(� � DataContext �� ��`� 	 �� StringFormat$	 {0} {1}��.1��� 
 �� Path$
 BeneficiaryFName��� $
 BeneficiaryLName�]� ��.  $��0,50,0,0q�.+��� -    ��Name$ FNameBox��$��
First Name��$��Right=��� $	��283������ *	FirstName+$ TwoWay=�$ PropertyChanged=�]� .+��� -   $ LNameBox��$��	Last Name���� $	��283������ *
LastName+$ TwoWay=�$ PropertyChanged=�]� ��. .+��� -   $ PESElBox��$��PESEL����   validationErrorTemplate =� ErrorTemplate# [ $	��283��.������ $
 Pesel�$ TwoWay=�$ PropertyChanged=� �� ValidationRules 6   0KeeperRichClient.Modules.Benefits.PeselValidator  .��]� ��.  .+��� $��Date of Birth���� $
��YYYY��$��36���� 
�������$��62��$��Center=�$��Center=����� *YearFromPesel+$ OneWay=�$ PropertyChanged=��� $��MM���� $��62�� �� 
IsReadOnly . $��Center=�$��Center=����� *MonthFromPesel+$ OneWay=��� $��DD���� $��71�� . $��Center=�$��Center=����� *DayFromPesel+$ OneWay=�]� ��. .+��� -   $ 
AddressBox��$��Citizenship���� ���� *CitizenShip+$ OneWay=�]� ��. .+��� $	��Sex���� $	��283��$
��Left=����� *SexFromPesel+$ OneWay=�]� ��. .+��� $��Phone Number���� ���� *PhoneNumber+$	 ###-###-###��]� ��. .+��� -   $ IdCardNumber��$��Email Address���� # [ .������ $
 EmailAddress�$ TwoWay=�$ PropertyChanged=� 6   0KeeperRichClient.Modules.Benefits.EmailValidator  .���� -    ��Name$ 	SaveBenef��$
��Save��$
��Left=�$��30��$��
93,376,0,0q�$	��Top=�$	��134�� J� RenderTransformOrigin$ 
0.597,-1.2&�  SimpleButton#���  ���� *SaveNewBenef+�� -   $ CancelSaveBenef��$��Cancel��$
��Left=�$��30��$��232,376,0,0q�$	��Top=�$	��141��#���  