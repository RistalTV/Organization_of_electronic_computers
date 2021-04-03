# Компиляция python проектов
1. Если не установле PyInstaller то:
    - В консоли вводим:
        * win: pip install pyinstaller
	    * linux pip3 install pyinstaller
2.  В консоли вводим: 
    - "pyinstaller test.py" - Ваш исполняемый файл будет создан в папке под названием dist в директории вашей программы Python.
	- "pyinstaller --onefile test.py" - создать один исполняемый файл.
	- "pyinstaller -w test.py" -  использовать флажки -w или –noconsole, чтобы спрятать окно консоли.(Эта опция доступна только для Windows и Mac OS X)
	- "pyinstaller --help" - Pyinstaller предоставляет множество вариантов для упаковки вашего приложения, чтобы увидеть полный список, используйте –help.