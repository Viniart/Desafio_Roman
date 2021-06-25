import React, { Component } from 'react';
import { TouchableOpacity,  Image, ImageBackgroundBase,StyleSheet,Text,TextInput,Pressable,View } from 'react-native';
import  AsyncStorage  from '@react-native-async-storage/async-storage';

import api from '../services/api';
import vandiesel from '../../assets/logo.png';

export default class Login extends Component {
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
            const resposta = await api.post('/Login', {
                email : this.state.email,
                senha : this.state.senha
            }) 

            console.warn(this.state.email)
            console.warn(this.state.senha)

            const token = resposta.data.token;

            await AsyncStorage.setItem('userToken', token);

            console.warn(token)

            this.props.navigation.navigate('Projetos');


        } catch(erro) {
            console.warn(erro)
        }

        
    };

    render(){
        return(
            <View style={styles.overlay}>

            {/* <View style={styles.aaaaa}>
                <Image
                    style={styles.tinyLogo}
                    source={require('../../assets/logo.png')}
                />
            </View> */}


                <View style={styles.main}>

                <View style={styles.aaaaa}>
                <Image
                    style={styles.tinyLogo}
                    source={require('../../assets/logo.png')}
                />

            </View>
                    
                    <TextInput 
                        style={styles.inputLogin}
                        placeholder=" Username"
                        keyboardType="email-address"
                        onChangeText={email => this.setState({ email })}
                    />

                    <TextInput 
                        style={styles.inputLogin}
                        placeholder=" Password"
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                    />

                             {/* <Pressable
                                 style={styles.btnSenha}
                             >
                                 <Text style={styles.btnSenha}>hjnsil</Text>
                             </Pressable> */}

                    <Pressable
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}
                    >
                        <Text style={styles.btnLoginText}>Login</Text>
                    </Pressable>

                    <Pressable
                        style={styles.btnLink}
                    >
                        <Text style={styles.btnLink}>Clique aqui para se cadastrar!</Text>
                    </Pressable>  
                </View>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: '#12294B'
    },
    aaaaa: {
        width: '80%',
        height: '30%',
        marginRight: '5em',
        alignItems: 'center',
        //justifyContent: 'center',
       // backgroundColor: 'red',
        marginTop: '1em',

    },
    main: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
        //backgroundColor:'yellow'

    },

    tinyLogo: {
        width: '30%',
        height: '30%',
      },

    mainImgLogin:{
        width: 90,
        margin: 60,
        marginTop:0,
        
    },

    inputLogin: {
        width: 315,
        marginBottom: 40,
        fontSize: 20,
        color: '#FFF',
        borderColor: '#B7B8A3',
        borderWidth: 2,
        borderRadius: '10px'
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 35,
        width: 210,
        backgroundColor: '#FFF',
        borderColor: '#B7B8A3',
        borderWidth: 1,
        borderRadius: 4,
        marginTop: 20,
        
    },

    btnLoginText: {
        fontSize: 15,
        fontFamily: 'Arial',
        color: '#580C30',
        textTransform: 'uppercase',
        
    },

    btnLink:{
        color: '#ffff',
        marginTop: '0.3em',
        textDecorationLine: 'underline', 
        fontSize: '15px'

    },

   

    
});