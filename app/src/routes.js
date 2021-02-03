import React from 'react'
import './index.css'
import Events from '@containers/Events'
import SensorAdd from '@containers/Sensor/Add'
import SensorList from '@containers/Sensor/List'
import NotFound from '@containers/NotFound'
import registerServiceWorker from './registerServiceWorker'
import { BrowserRouter, Switch, Route } from 'react-router-dom'

const Routes = () => (
    <BrowserRouter>
        <Switch>
            <Route path="/" exact={true} component={Events} />
            <Route path="/dashboard" exact={true} component={Events} />
            <Route path="/sensors" exact={true} component={SensorList} />
            <Route path="/sensors/add" exact={true} component={SensorAdd} />
            <Route component={NotFound} />
        </Switch>
    </ BrowserRouter>
);

registerServiceWorker();

export default Routes;