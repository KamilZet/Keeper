   M S B A M L   `   `   `  ����\  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  5      G    AKeeperRichClient.Modules.Benefits.Views.NewBeneficiaryDetailsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:KeeperRichClient.Modules.Benefits     5      $	��266��5   3   .��5      � .+�5	   
   ��   � 	Resources  5
       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 90��6.   �� 5       � ��$ 10,0,0,0q�6/   �� 5       � ��$
 Bold"�63   5      5      .+�5      ]� ��.  $��0,50,0,0q�6.   .+�5      �� -   5         ��Name$ FNameBox��5      $��
First Name��6.   $��Right=�6@   �� 5      $	��200��6g   $
��Left=�6s   ��6   �� *	FirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6s   5      ]� 5      ��.  .+�5      �� -   5        $ LNameBox��5      $��	Last Name��6.   �� 5      $	��200��6f   $
��Left=�6r   ��6   �� *
LastName+$ TwoWay=�$ PropertyChanged=�6r   5      ]� 5      ��.  .+�5      �� -   5        $ PESElBox��5      $��PESEL��6.   �� 5         validationErrorTemplate =� ErrorTemplate# [  6   $	��200��6_   $
��Left=�6k   .��6�   ��5      �� 5       �� Path$ Pesel�6"   $ TwoWay=�6/   $ PropertyChanged=�6=   	 �� ValidationRules	 5      6   0KeeperRichClient.Modules.Benefits.PeselValidator  5    "   5"      .��5#   $   5$      5%      ]� 5&      ��.  .+�5'      �� $��Date of Birth��6   �� 5(      $
��YYYY��6   $��36��6'   �� 5)      
�������$��45��6-   
 �� 
IsReadOnly
 . $��Center=�6J   $��Center=�6g   ��5*      �� *YearFromPesel+$ OneWay=�$ PropertyChanged=��� 5+      $��MM��6   �� 5,      $��37��6   
 . $��Center=�67   $��Center=�6T    J� RenderTransformOrigin$ 0.5,0.5&�5-   G   ��6   �� *MonthFromPesel+$ OneWay=�.��6g   5.      �� 5/      $��DD��6   �� 50      $��30��6   
 . $��Center=�67   $��Center=�6T   ��51      �� *DayFromPesel+$ OneWay=�52      ]� 54      ��.  .+�55      �� -   5        $ 
AddressBox��55      $��Citizenship��60   �� 56      $	��200��6C   $
��Left=�6O   ��6   �� *CitizenShip+$ OneWay=�6O   57      ]� 58      ��.  .+�59      �� $	��Sex��6   �� 5:      
 . $	��200��5;   A   $
��Left=�6M   ��6   �� *SexFromPesel+$ OneWay=�6M   5=      ]� 5>      ��.  .+�5?      �� $��Phone Number��6   �� 5@      $	��200��6P   $
��Left=�6\   ��6   �� *PhoneNumber+ �� StringFormat$ ###-###-###��6\   5A      ]� 5C      ��.  .+�5D      �� -   5        $ IdCardNumber��5D      $��Email Address��62   �� 5E      # [  6   $	��200��5F      $
��Left=�6"   .��6=   ��5G      �� 5H      $ EmailAddress�6"   $ TwoWay=�66   $ PropertyChanged=�6D   	 5I      6   0KeeperRichClient.Modules.Benefits.EmailValidator  5J   "   5L      .��5M   $   5N      5O      5P      5Q      5R      