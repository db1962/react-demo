import React, { useState, useEffect } from "react";
import DataGrid from 'react-data-grid'


// function getRowId(row) {
//     return row.Id;
// }

function onRowChanged() {

}


export default function ProposalData() {
    
    const [rows, setRows] = useState([])
   
    const getData = () => {
        fetch('https://localhost:7211/api/Proposals')
            .then((res) => res.json())
            .then((res) => {

                setRows(res)
            })
    }

    useEffect(()=> {
        getData();
    }, [])

    const columns = [
        {
            key: 'expanded',
            name: '',
            minWidth: 30,
            width: 30,
            
        },
        {key:'id',name:'Id'},
        {key:'proposalName', name: 'Proposal Name'},
        {key:'customerGrpName', name: 'Customer Name'},
        {key:'date', name: 'Date Modified'},
        {key:'description', name: 'Description'},
        {key:'proposalStatus', name: 'Status'}
    ]

  

    return (<DataGrid columns={columns} rows={rows}  
    onRowsChange={onRowChanged}
    />)
   
}
