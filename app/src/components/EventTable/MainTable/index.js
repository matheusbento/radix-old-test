import React from "react";
import {
    Container,
    CartEvents,
    CartEmpty
} from './styles'
import { Card, Alert, Table } from 'antd';
import moment from 'moment';

const MainTable = props => {
    const columns = [
        {
            title: 'Sensor',
            key: 'sensor',
            dataIndex: 'sensor',
            render: sensor => (
                <span>
                    {`${sensor.Country}.${sensor.Region}.${sensor.Name}`}
                </span>
            ),
        },
        {
            title: 'Value',
            dataIndex: 'value',
            key: 'value',
        },
        {
            title: 'Timestamp',
            dataIndex: 'date',
            key: 'date',
        },
    ];

    const data = props.events.map((item, index) => {

        var time = moment(item.Timestamp).format("DD/MM/YYYY hh:mm:ss");

        return {
            key: item.Id,
            sensor: item.Sensor,
            value: item.Value,
            date: time
        }
    });

    return (
        <Container>
            <Card style={{ width: "100%" }}>
                <CartEvents>
                    {props.events.length ?
                        <>
                            <Table columns={columns} dataSource={data} size="small" />
                        </>
                        : (
                            <CartEmpty>
                                <Alert message="OPS! Your table is empty" type="warning" />
                            </CartEmpty>
                        )
                    }
                </CartEvents>
            </Card>
        </Container>
    )
}

export default MainTable