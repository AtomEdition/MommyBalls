public class Singleton<T> where T : new() {

	private static T instance;

	private Singleton(){
	}

	public static T getInstance(){
		if (instance == null) {
			instance = new T();
		}
		return instance;
	}
}
