   M S B A M L   `   `   `  ����\  XKeeperRichClient.Modules.Benefits, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KeeperRichClient.Modules.Benefits!KeeperRichClient.Modules.Benefits  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   =    7KeeperRichClient.Modules.Benefits.AddNewBeneficiaryView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Dbenefits/clr-namespace:KeeperRichClient.Modules.Benefits     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	      WindowBrush#��[  5	   	   $	��532��63   $	��499��6@     � 	Resources  5
       �� 
TargetType �� Property �� Value��%8  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 80��6&   �� 5       � ��$ 1��6,   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � ��$	 283��6&   �� 5       � ��$ 1��6,   �� 5       � ��$
 Left=�64   5      5      .��5      �  � ColumnDefinitions 5   
   .+�5!   
   �� $��10q�6   .+�5"      �� $��Beneficiary Personal Data��6   $��Center=�68   $��12,20,11,20q�6U   $��18(�5#      $��	ExtraBold"�6"   $	��260��69   $��36��6E   �� 5$      $��Center=�6   $��29��64   $	��281��6@     SimpleComboBox#��[ 6L   $��
85,0,105,0q�5'      ��5%      �� *GetBeneficiaries+ �� SelectedItem 5&      �� *Beneficiary+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5*      �� 5+      .R�5,      �� $��20(�6<    � DataContext 6$   �� ��5-      `� 5.   "   	 �� StringFormat$	 {0} {1}��6/   .1�5/   &   �� 
 �� Path$
 BeneficiaryFName�6.   �� 50   &   $
 BeneficiaryLName�6.   51   #   53      54      56      ]� 57      ��.  $��0,50,0,0q�6.   .+�58      �� -   5         ��Name$ FNameBox��58      $��
First Name��6.   $��Right=�6@   �� 59      $	��283��6g   ��6   �� *	FirstName+$ TwoWay=�$ PropertyChanged=�6g   5;      ]� 5<      .+�5=      �� -   5        $ LNameBox��5=      $��	Last Name��6.   �� 5>      $	��283��6f   ��6   �� *
LastName+$ TwoWay=�$ PropertyChanged=�6f   5?      ]� 5@      ��. .+�5A      �� -   5        $ PESElBox��5A      $��PESEL��6.   �� 5C        validationErrorTemplate =� ErrorTemplate# [ 6   $	��283��6_   .��6k   ��5D      �� 5E      $
 Pesel�6"   $ TwoWay=�6/   $ PropertyChanged=�6=    �� ValidationRules 5F      6   0KeeperRichClient.Modules.Benefits.PeselValidator  5G   "   5I      .��5J   $   5K      5L      ]� 5M      ��.  .+�5N      �� $��Date of Birth��6   �� 5O      $
��YYYY��6   $��36��6'   �� 5P      
�������$��62��6-   $��Center=�68   $��Center=�6U   ��5Q      �� *YearFromPesel+$ OneWay=�$ PropertyChanged=��� 5R      $��MM��6   �� 5S      $��62��6    �� 
IsReadOnly . $��Center=�67   $��Center=�6T   ��5T      �� *MonthFromPesel+$ OneWay=��� 5U      $��DD��6   �� 5V      $��71��6    . $��Center=�67   $��Center=�6T   ��5W      �� *DayFromPesel+$ OneWay=�5X      ]� 5\      ��. .+�5]      �� -   5        $ 
AddressBox��5]      $��Citizenship��60   �� 5^      ��6   �� *CitizenShip+$ OneWay=�5_      ]� 5`      ��. .+�5a      �� $	��Sex��6   �� 5b      $	��283��6   $
��Left=�6&   ��5c      �� *SexFromPesel+$ OneWay=�5e      ]� 5f      ��. .+�5g      �� $��Phone Number��6   �� 5h      ��6   �� *PhoneNumber+$	 ###-###-###��5i      ]� 5u      ��. .+�5v      �� -   5        $ IdCardNumber��5v      $��Email Address��62   �� 5w      # [ 6   .��6^   ��5x      �� 5y      $
 EmailAddress�6"   $ TwoWay=�66   $ PropertyChanged=�6D    5z      6   0KeeperRichClient.Modules.Benefits.EmailValidator  5{   "   5}      .��5~   $   5      5�      5�      �� 5�   
   -   5         ��Name$ 	SaveBenef��5�      $
��Save��5�      $
��Left=�6    $��30��6;   $��
93,376,0,0q�6G   $	��Top=�6[   $	��134��6s    J� RenderTransformOrigin$ 
0.597,-1.2&�5�   2     SimpleButton#���  5�      ��5�      �� *SaveNewBenef+5�      �� 5�   
   -   5        $ CancelSaveBenef��5�      $��Cancel��5�      $
��Left=�6"   $��30��6=   $��232,376,0,0q�6I   $	��Top=�6^   $	��141��6v   #���  5�      5�      5�      