   M S B A M L   `   `   `  ����%  !KeeperRichClient.Modules.Benefits=    7KeeperRichClient.Modules.Benefits.DeactivateBenefitView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5         WindowBrushRev#���   5      $	��300��5      $	��502��6   .��5	      � .+�5
   
   �� $��1q�6   
�������$��	10,12,6,0q�69   $��50��6L   $	��Top=�6X   ._�5      �� $��16(�6   $��Normal$�6'   $��Arial)�6:   $
��Left=�5      $��46��6.   $��10,9,0,0q�6:   $
��Wrap=�6L   $	��Top=�6`   $	��251��6x   $L��FPlease select the last active day of benefit service you want to close��5      5      5      (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6   $��35��60   $��	12,67,0,0q�6<   $	��Top=�6O   $	��274��6g     MyDatePicker#��[ 5          SelectedDate  5      �� *	EndDate+ �� Mode$ TwoWay=�5      �� 5   
   $
��Left=�6   $	��155��6-   $��
14,254,0,0q�6:    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��272��6z    �� AcceptsReturn . ��5      �� *
TakingNote+�� 5   
   $��1q�6   
�������$��
14,199,6,0q�69   $��50��6M   $	��Top=�6Y   ._�5      �� $��16(�6   $��Normal$�6'   $��Arial)�6:   $
��Left=�5      $��46��6&   $��10,9,0,0q�62   $
��Wrap=�6D   $	��Top=�6X   $	��251��6p   $%��Leave a comment, if you want...��5      5      �� 5   
   $��1q�6   
�������$��
14,110,6,0q�69   $��50��6M   $	��Top=�6Y   ._�5      �� $��16(�6   $��Normal$�6'   $��Arial)�6:   $
��Left=�5      $��46��6&   $��10,9,0,0q�62   $
��Wrap=�6D   $	��Top=�6X   $	��251��6p   �� 5       $�Please��6   �� 6!   $� s��6%   �� 61   $8�2elect reason for closing selected benefit service:��65   6r   5!      �� 5"   
   $
��Left=�6   $��30��6.   $��
14,165,0,0q�6:   $	��Top=�6N   $	��270��6f     SimpleComboBox#��[ 5#       �� DisplayMemberPath$ TakingReasonName��5&      ��5%      �� *TakingReasonTypeList+ �� SelectedItem 5'      �� *SelectedTakeType+�� 5)   
   $
��Save��6   $
��Left=�6    $��28��6;   $��
14,414,0,0q�6G   $	��Top=�6[   $	��121��6s     SimpleButton#���  5*      ��5+      �� *CallDeactivateBenefit+�� 5-   
   $��Cancel��6   $
��Left=�6"   $��28��6=   $��155,414,0,0q�6I   $	��Top=�6^   $	��131��6v   #���  5.       �� IsCancel . 5/      53      54      