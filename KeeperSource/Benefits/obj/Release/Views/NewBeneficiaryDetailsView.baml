   M S B A M L   `   `   `  ���� \  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  G    AKeeperRichClient.Modules.Benefits.Views.NewBeneficiaryDetailsView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:KeeperRichClient.Modules.Benefits     $	��266��.��� .+���   � 	Resources   �� 
TargetType �� Property �� Value��%a   '��       �� " ��.���  � ��$ 90����  � ��$ 10,0,0,0q���  � ��$
 Bold"�.+�]� ��.  $��0,50,0,0q�.+��� -    ��Name$ FNameBox��$��
First Name��$��Right=��� $	��200��$
��Left=����� *	FirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�]� ��.  .+��� -   $ LNameBox��$��	Last Name���� $	��200��$
��Left=����� *
LastName+$ TwoWay=�$ PropertyChanged=�]� ��.  .+��� -   $ PESElBox��$��PESEL����    validationErrorTemplate =� ErrorTemplate# [  $	��200��$
��Left=�.������  �� Path$ Pesel�$ TwoWay=�$ PropertyChanged=�	 �� ValidationRules	 6   0KeeperRichClient.Modules.Benefits.PeselValidator  .��]� ��.  .+��� $��Date of Birth���� $
��YYYY��$��36���� 
�������$��45��
 �� 
IsReadOnly
 . $��Center=�$��Center=����� *YearFromPesel+$ OneWay=�$ PropertyChanged=��� $��MM���� $��37��
 . $��Center=�$��Center=� J� RenderTransformOrigin$ 0.5,0.5&����� *MonthFromPesel+$ OneWay=�.���� $��DD���� $��30��
 . $��Center=�$��Center=����� *DayFromPesel+$ OneWay=�]� ��.  .+��� -   $ 
AddressBox��$��Citizenship���� $	��200��$
��Left=����� *CitizenShip+$ OneWay=�]� ��.  .+��� $	��Sex���� 
 . $	��200��$
��Left=����� *SexFromPesel+$ OneWay=�]� ��.  .+��� $��Phone Number���� $	��200��$
��Left=����� *PhoneNumber+ �� StringFormat$ ###-###-###��]� ��.  .+��� -   $ IdCardNumber��$��Email Address���� # [  $	��200��$
��Left=�.������ $ EmailAddress�$ TwoWay=�$ PropertyChanged=�	 6   0KeeperRichClient.Modules.Benefits.EmailValidator  .��