# AndroidCalcApp

Инструкция:


1. Клонирование репозитория в Visual Studio:

1.1. Через github:

1.1.1. На https://github.com/MrVoodoPeople/AndroidCalcApp нажмите на кнопку "<> Code".

1.1.2. В появившемся окне нажмите Open with Visual Studio (Visual Studio должен быть установлен).

1.1.3. Выберите путь, после чего нажмите "Клонировать".

1.2. Через консоль:

1.2.1. В консоли напишите команду cd <path>, где path - путь к каталогу, в который нужно клонировать репозиторий:

1.2.1.1. для Linux: $ cd /home/user/<...>/<название каталога>

1.2.1.2. для macOS: $ cd /Users/user/<...>/<название каталога>

1.2.1.3. для Windows: $ cd C:/Users/user/<...>/<название каталога>

1.2.2. В консоли напишите команду "git clone https://github.com/MrVoodoPeople/AndroidCalcApp.git".


2.Cборка проекта:

2.1. Выберите в обозревателе решений (Solution Explorer) нужное решение (AndroidCalculator.Android для сборки Android проекта).

2.2. В строке меню выберите Сборка, затем нажмите Сборка AndroidCalculator.Android.


3. Создание apk:

3.1. В Visual Studio нажмите правой кнопкой мыши на AndroidCalculator.Android в обозревателе решений (Solution Explorer).

3.2. Перейдите к свойствам, затем Android -> Параметры.

3.3. Убедитесь, что Формат пакета Android имеет значение "apk"

3.4. Измените конфигурации решения на Release

3.5. Нажмите правой кнопкой мыши на AndroidCalculator.Android в обозревателе решений, затем выберите "Архивация...". Апк создан!