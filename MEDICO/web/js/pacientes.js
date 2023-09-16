new Vue({
    el: '#app',
    data: {
        pacientes: [],
        pacienteEditado: {},
        nuevoPaciente: {
            NOMBRE: '',
            EDAD: null,
            FEC_ING: null
        },
    },
    created() {
        this.getPacientes()

    },
    methods: {
        limpiarFormulario() {
            // Lógica para limpiar los campos del formulario después de guardar
            this.nuevoPaciente = {
                NOMBRE: '',
                EDAD: null,
                FEC_ING: null
            };
        },guardarNuevoPaciente() {
            fetch('https://localhost:44357/api/paciente/crear',
                {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(this.nuevoPaciente),
                    redirect: 'follow'
                }
            ).then(response => response.json())
                .then(datosEmpresa => {
                    this.getPacientes()
                    // Manejar la respuesta del servidor (puedes mostrar un mensaje de éxito, por ejemplo)
                    
                    // Limpiar los datos del formulario o realizar otras acciones necesarias
                    this.limpiarFormulario();
                    // Cerrar el modal después de guardar
                    $('#modalNuevoPaciente').modal('hide');
                    this.showError({ text: datosEmpresa.message, icon: 'success', })
                })
                .catch(error => {
                    // Manejar los errores de la solicitud (puedes mostrar un mensaje de error)
                    this.showError({ text: error });
                });
        },
        showError(options = {}) {
            const defaultOptions = {
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!',
            }
            const swalOptions = { ...defaultOptions, ...options }
            Swal.fire(swalOptions)
        },
        getPacientes() {

            var self = this
            return fetch('https://localhost:44357/api/paciente/pacientes')
                .then((response) => response.json())
                .then((datosEmpresa) => {
                    return (self.pacientes = datosEmpresa.data)
                })
                .catch((error) => {
                    self.showError({ text: error })
                })
        }, abrirModalEdicion(paciente) {
            this.pacienteEditado = { ...paciente }; // Copia los datos del paciente
            $('#modalEdicion').modal('show'); // Muestra el modal
        },
        cerrarModalEdicion() {
            this.pacienteEditado = {}; // Borra los datos del paciente editado
            $('#modalEdicion').modal('hide'); // Oculta el modal
        },
        PacienteAEliminar(idPacienteAEliminar) {

            var self = this;
            fetch(`https://localhost:44357/api/paciente/eliminar/${idPacienteAEliminar}`,
                {
                    method: 'POST',
                    "headers": {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(this.pacienteEditado),
                    redirect: 'follow'
                }
            ).then((response) => response.json())
                .then((datosEmpresa) => {
                    self.showError({ text: datosEmpresa.message, icon: 'success', })
                    this.getPacientes()
                })
                .catch((error) => {
                    self.showError({ text: error })
                })
            this.cerrarModalEdicion();
        },guardarEdicion() {
            
            var self = this;
            fetch('https://localhost:44357/api/paciente/editar',
                {
                    method: 'POST',
                    "headers": {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(this.pacienteEditado),
                    redirect: 'follow'
                }
            ).then((response) => response.json())
                .then((datosEmpresa) => {
                    self.showError({ text: datosEmpresa.message, icon: 'success', })
                    this.getPacientes()
                })
                .catch((error) => {
                    self.showError({ text: error })
                })
            this.cerrarModalEdicion();
        },


        // Otros métodos relacionados con el carrito aquí
    },
})


