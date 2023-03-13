namespace laba_8_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Massiv<int> intArray = new Massiv<int>(new int[] { 1, 2, 3 });
            Massiv<string> stringArray = new Massiv<string>(new string[] { "my", "cat", "азарник"});
            Massiv<double> doubleArray = new Massiv<double>(new double[] { 3.4, 300.333, 789.00044 });

            intArray.dobavit(4);
            intArray.delete(3);
          
            intArray.print();
            
            Console.WriteLine(intArray.get(1));
            Console.WriteLine(intArray.getLength());

            stringArray.dobavit("!");
            stringArray.delete("азарник");
            stringArray.print();

            doubleArray.dobavit(8.9);
            doubleArray.delete(300.333);
            doubleArray.print();

            Console.WriteLine();

            User pup = new User("Pup", "3673");
            User fuf = new User("Fuf", "3764");

            User.loginArray.print();

            Console.WriteLine();
            User.passArray.print();
        }
    }

    class User
{
    public string login;
    public string password;
    public static LogonMass loginArray = new LogonMass();
    public static PasMass passArray= new PasMass();
    public User(string login, string password)
    {
        this.login = login;
        this.password = password;
        loginArray.dobavit(login);
        passArray.dobavit(password);
    }
}


class LogonMass : Massiv<string>
{
    public LogonMass(params string[] mass) : base(mass)
    {

    }
}

class PasMass : Massiv<string>
{
    public PasMass(params string[] mass) : base(mass)
    {

    }
}

    class Massiv<T>
    {
        T[] array;

        public Massiv(T[] mass) //конструктор
        {
            array = mass;
        }

        public void dobavit(T item)//метод добавления одного элемента в массив
        {
            T[] Array = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                Array[i] = array[i];
            }
            Array[array.Length] = item;
            array = Array;
        }
        public void delete(T item) //удаление одного элемента
        {
            T[] Array = new T[array.Length - 1];

            int j = -1; //чтобы не выйти за границы нового массива
            bool udolit = false; //если удалили 1 элемент, то остальные точно такие же одиноаковые удалены не будут

            for (int i = 0; i < array.Length; i++)
            {
                j++;
                if (array[i].Equals(item) && !udolit) //элемент совпал и мы его не удалили
                {                                    //если встречаем элемент , который нужно удалить, мы его не присваиваем
                    udolit = true;
                    j--;
                    continue; //элемент удаляем и пропускаем итерацию
                }
                Array[j] = array[i];
            }
            array = Array;
        }
        public void print() // метод вывода массива на консольль
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public T get(int index) //получает элемент по индексу
        {
            return array[index];
        }
        public int getLength() //возвращает длину массива
        {
            return array.Length;
        }
    }
}
  