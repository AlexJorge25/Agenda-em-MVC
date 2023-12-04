namespace AgendaMVC.Interface
{
	public interface Icrud<T>
	{
		bool salvar(T t);
		bool Editar(T t);
		void Deletar(int id);
		T Consultar(int id);
		List<T> Consultar();
	}
}
