const toastLiveExample = document.getElementById('liveToast');
const guardarBtn = document.querySelector('#btnGuardar');
const txtNombre = document.querySelector('#txtNombre');
const txtPrecio = document.querySelector('#txtPrecio');
const txtCantidad = document.querySelector('#txtCantidad');
const table = document.querySelector('#table');
const tbody = document.querySelector('#tbody');
const subtotal = document.querySelector('#subtotal');
const ISV = document.querySelector('#ISV');
const descuento = document.querySelector('#descuento');
const total = document.querySelector('#total');
const agregar = document.querySelector('#agregar');
const f = new Intl.NumberFormat('es-HN', {
    style: 'currency',
    currency: 'HNL',
    minimumFractionDigits: 2
});

let productos = [{
        id: 1,
        nombre: 'producto1',
        precio: 12.5,
        cantidad: 10,
    },
    {
        id: 2,
        nombre: 'producto2',
        precio: 22.5,
        cantidad: 20,
    },
    {
        id: 3,
        nombre: 'producto3',
        precio: 32,
        cantidad: 30,
    }
];

if (guardarBtn) {
    guardarBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (txtNombre.value === '' || txtPrecio.value === '' || txtCantidad.value === '') {
            alert('Debe rellenar todos los campos')
        } else {
            const id = productos.length + 1;
            const nombre = txtNombre.value;
            txtNombre.value = '';
            const precio = txtPrecio.value;
            txtPrecio.value = '';
            const cantidad = txtCantidad.value;
            txtCantidad.value = '';
            productos.push({ id, nombre, precio, cantidad });
            document.querySelector('#SeccionTabla').classList.toggle('oculto');
            document.querySelector('#productoNuevo').classList.toggle('oculto');
            const toast = new bootstrap.Toast(toastLiveExample);
            toast.show()
            llenarTabla();
        }
    });
}


agregar.addEventListener('click', () => {
    document.querySelector('#SeccionTabla').classList.toggle('oculto');
    document.querySelector('#productoNuevo').classList.toggle('oculto');
});


const llenarTabla = () => {
    tbody.innerHTML = '';
    let auxSubtotal = 0;
    productos.forEach(producto => {
        auxSubtotal += (producto.precio * producto.cantidad);
        tbody.innerHTML += `
        <tr>
            <td>${producto.id}</td>
            <td>${producto.nombre}</td>
            <td>${f.format(producto.precio)}</td>
            <td>${producto.cantidad}</td>
            <td>${(f.format(producto.precio * producto.cantidad))}</td>
        </tr>
    `;
    });
    subtotal.innerHTML = `&nbsp;${f.format(auxSubtotal)}`;
    const isv = auxSubtotal * .15
    ISV.innerHTML = '&nbsp;' + f.format(isv);
    const desc = auxSubtotal * .1;
    descuento.innerHTML = '&nbsp;' + f.format(desc);
    tot = auxSubtotal - desc + isv;
    total.innerHTML = '&nbsp;' + f.format(tot);
}
llenarTabla();




// if (btn) {
//     btn.addEventListener('click', (e) => {
//         const toast = new bootstrap.Toast(toastLiveExample);
//         e.preventDefault();
//         toast.show()
//     })
// }