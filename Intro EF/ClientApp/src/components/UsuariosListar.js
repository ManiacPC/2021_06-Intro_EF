import React, { useEffect, useState } from 'react'
import {Button, Col, Row, Table} from 'reactstrap';
import axios from 'axios'

const UsuariosListar = () => {
    // Declaramos estados (variables)
    const [ listaUsuarios , setListaUsuarios ] = useState([]) // get - set 
    // const [get,set] = useState(<estado_inicial>)
    
    
    useEffect(() => {
        // Va a ejecutar cuando se cargue el componente (una vez al mostrarse al inicio)
        
        // Cuando uno efectúa una llamada a la api, se trabaja de forma asincrónica
        const cargarUsuarios = async() => { // async que indica llamada asíncrona
            let respuesta = await axios.get("https://localhost:44393/api/Usuarios/Lista") // guarda en la variable cuando termine la llamada asíncrona
            console.log(respuesta.data)
            setListaUsuarios(respuesta.data)
        }
        
        cargarUsuarios()
    }, [])
    
    const handleCambiarNombre = async() => {
        let id = 2
        let nuevoUsername = 'calvonn'
        
        let respuesta = await axios({
            url: 'https://localhost:44393/api/Usuarios/Update',
            method: 'post',
            data: {
                id: id,
                newName: nuevoUsername
            }
        }).then(resultado => {
            alert('Se han enviado los datos!')
        }).catch(error => {
            alert('Error al enviar!')
        })                                              
    }
    
    return (
        <>
            <h1>Listado de usuarios</h1>
            <Table>
                <thead>
                <tr>
                    <th>#</th>
                    <th>Usuario</th>
                    <th>Password (NO!)</th>
                </tr>
                </thead>
                <tbody>
                {listaUsuarios.map((usuario, index) => {
                        return (
                            <tr key={index}>
                                <th scope="row">{usuario.id}</th>
                                <td>{usuario.username}</td>
                                <td>{usuario.password}</td>
                            </tr>
                        )
                    }
                )}
                </tbody>
            </Table>
            
            <hr />
            <Row>
                <Col>
                    <Button onClick={handleCambiarNombre} className='float-right' color="primary">Cambiar "calvin" a "calvon"</Button>
                </Col>
            </Row>
        </>
    )
}

export default UsuariosListar
