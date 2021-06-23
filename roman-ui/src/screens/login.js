import React, {Component} from 'react';
import { ImageBackgroundBase,StyleSheet,Text,TextInput,Pressable,View } from 'react-native';
import { AsyncStorage } from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    }

    // Lembrar que assíncrono é uma forma de trabalhar com promises
    realizarLogin = async () => {
        try {
            const resposta = await api.post('/login', {
                email : this.state.email,
                senha : this.state.senha
            }) 

            const token = resposta.data.token;

            await AsyncStorage.setItem('userToken', token);

            this.props.navigation.navigate('Projetos');


        } catch(erro) {
            console.warn(erro)
        }
    };

    render(){
        return(
            <View style={styles.overlay}>
                <View style={styles.main}>
                    
                </View>
            </View>
        )
    }
}