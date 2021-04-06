import sys
from PyQt5.QtWidgets import QApplication
from lab_1.Windows.login_Window import login_Window
from lab_1.Windows.create_Window import create_Window
from lab_1.Windows.view_Window import view_Window

if __name__ == '__main__':
    app = QApplication([])

    view_Win = view_Window()
    Login_Window = login_Window(
        Create_Window=create_Window(view_Win),
        View_Window=view_Win
    )

    Login_Window.show()
    sys.exit(app.exec())
