public class Singleton<T> where T : new() {

	private static T instance;

	private Singleton(){
	}

	public static T GetInstance(){
		if (object.Equals(instance, default(T))) {
			instance = new T();
		}
		return instance;
	}
}
