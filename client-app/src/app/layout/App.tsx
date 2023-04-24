import React, { useEffect } from 'react';
import NavBar from './NavBar';
import ActivityDashboard from './../../features/activities/dashboard/ActivityDashboard';
import { Route, Switch, useLocation } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import ActivityForm from '../../features/activities/form/ActivityForm';
import ActivityDetails from './../../features/activities/details/ActivityDetails';
import TestErrors from './../../features/errors/TestError';
import NotFound from './../../features/errors/NotFound';
import { Container } from 'semantic-ui-react';
import { ToastContainer } from 'react-toastify';
import { observer } from 'mobx-react-lite';
import ServerError from '../../features/errors/ServerError';
import LoginForm from './../../features/users/LoginForm';
import ModalContainer from '../common/modals/ModalContainer';
import { useStore } from '../stores/store';
import LoadingComponent from './LoadingComponent';
import RegisterForm from '../../features/users/RegisterForm';


function App() {

  const location = useLocation();
  const {commonStore, userStore} = useStore();

  useEffect(()=>{
    if(commonStore.token){
      userStore.getUser().finally(()=>commonStore.setAppLoaded());
    }else{
      commonStore.setAppLoaded();
    }
  },[commonStore, userStore])

  if(!commonStore.appLoaded) return <LoadingComponent content='Loading app...'/>

  return (
    <>
      <ToastContainer position='bottom-right' hideProgressBar />
      {/* <ModalContainer /> */}
      <Route path='/' exact component={HomePage} />
      <Route
        path={'/(.+)'}
        render={()=>(
          <>
           <NavBar/>
           <Container style={{marginTop: '7em'}} >
            <Switch>
              <Route path='/activities' exact component={ActivityDashboard} />
              <Route path='/activities/:id' component={ActivityDetails} />
              <Route path={['/createActivity', '/manage/:id']} component={ActivityForm} key={location.key}/>
              <Route path='/errors' component={TestErrors}/>
              <Route path='/server-error' component={ServerError}/>
              <Route path='/login' component={LoginForm}/>
              <Route path='/register' component={RegisterForm}/>
              <Route component={NotFound} />
            </Switch>
            </Container>
          </>
  )}
      />
     
    </>
  );
}

export default observer(App);
