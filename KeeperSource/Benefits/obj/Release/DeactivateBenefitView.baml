   M S B A M L   `   `   `  ���� %  !KeeperRichClient.Modules.Benefits=    7KeeperRichClient.Modules.Benefits.DeactivateBenefitView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008        WindowBrushRev#���   $	��300��$	��502��.��� .+��� $��1q�
�������$��	10,12,6,0q�$��50��$	��Top=�._��� $��16(�$��Normal$�$��Arial)�$
��Left=�$��46��$��10,9,0,0q�$
��Wrap=�$	��Top=�$	��251��$L��FPlease select the last active day of benefit service you want to close��(  "System.Windows.Controls.DatePicker  $
��Left=�$��35��$��	12,67,0,0q�$	��Top=�$	��274��  MyDatePicker#��[     SelectedDate  �� *	EndDate+ �� Mode$ TwoWay=��� $
��Left=�$	��155��$��
14,254,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��272�� �� AcceptsReturn . ���� *
TakingNote+�� $��1q�
�������$��
14,199,6,0q�$��50��$	��Top=�._��� $��16(�$��Normal$�$��Arial)�$
��Left=�$��46��$��10,9,0,0q�$
��Wrap=�$	��Top=�$	��251��$%��Leave a comment, if you want...���� $��1q�
�������$��
14,110,6,0q�$��50��$	��Top=�._��� $��16(�$��Normal$�$��Arial)�$
��Left=�$��46��$��10,9,0,0q�$
��Wrap=�$	��Top=�$	��251���� $�Please���� $� s���� $8�2elect reason for closing selected benefit service:���� $
��Left=�$��30��$��
14,165,0,0q�$	��Top=�$	��270��  SimpleComboBox#��[  �� DisplayMemberPath$ TakingReasonName������ *TakingReasonTypeList+ �� SelectedItem �� *SelectedTakeType+�� $
��Save��$
��Left=�$��28��$��
14,414,0,0q�$	��Top=�$	��121��  SimpleButton#���  ���� *CallDeactivateBenefit+�� $��Cancel��$
��Left=�$��28��$��155,414,0,0q�$	��Top=�$	��131��#���   �� IsCancel . 