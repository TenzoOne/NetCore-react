import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Button from "../utils/Button";
import { urlGeneros } from "../utils/endpoints";
import ListadoGenerico from "../utils/ListadoGenerico";
import Paginacion from "../utils/Paginacion";
import { generoCreacionDTO, generoDTO } from "./generos.model";

export default function IndiceGeneros() {
  const [generos, setGeneros] = useState<generoDTO[]>();
  const [errores, setErrorest] = useState<string[]>([]);
  const [totalDePaginas, setTotalDePaginas] = useState(0);
  const [recordsPorPagina, setRecordsPorPagina] = useState(5);
  const [pagina, setPagina] = useState(1);

  useEffect(() => {
    axios
      .get(urlGeneros, { params: { pagina, recordsPorPagina } })
      .then((respuesta: AxiosResponse<generoDTO[]>) => {
        const totalRegistros = parseInt(
          respuesta.headers["cantidadTotalregistros"],
          10
        );
        setTotalDePaginas(Math.ceil(totalRegistros / recordsPorPagina));
        console.log(respuesta.data);
        setGeneros(respuesta.data);
      });
  }, [pagina,recordsPorPagina]);
  /*
  async function eliminar(genero: generoCreacionDTO) {
    try {
      await axios.delete();
    } catch (error) {
      console.log(error);
      setErrorest(error);
    }
  }
*/
  return (
    <>
      <h3>Indice Géneros</h3>
      <Link className="btn btn-primary" to="generos/crear">
        Crear Género
      </Link>

      <Paginacion
        paginaActual={pagina}
        cantidadTotalPaginas={totalDePaginas}
        radio={0}
        onChange={(nuevapagina) => setPagina(nuevapagina)}
      />

      <ListadoGenerico listado={generos}>
        <table className="table table-striped">
          <thead>
            <tr>
              <th></th>
              <th>Nombre</th>
            </tr>
          </thead>
          <tbody>
            {generos?.map((genero) => (
              <tr key={genero.id}>
                <td>
                  <Link
                    className="btn btn-success"
                    to={`/generos/editar/${genero.id}`}
                  >
                    Editar
                  </Link>
                  <Button
                    onClick={() => {
                      axios.delete(genero.id.toString()).then();
                    }}
                    className="btn btn-danger"
                  >
                    Borrar
                  </Button>
                </td>
                <td>{genero.nombre}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </ListadoGenerico>
    </>
  );
}
