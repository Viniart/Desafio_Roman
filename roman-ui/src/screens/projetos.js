import React, { Component } from 'react';
import { ImageBackgroundBase,StyleSheet,Text,TextInput,Pressable,View,FlatList } from 'react-native';
import  AsyncStorage  from '@react-native-async-storage/async-storage';

import api from '../services/api'

export default class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaProjetos : []
        }
    }

    // Lembrar que assíncrono é uma forma de trabalhar com promises
    buscarProjetos = async () => {
        const resposta = await api.get('/projeto');
        const dados = resposta.data;

        this.setState({ listaProjetos : dados })
    };

    componentDidMount(){
        this.buscarProjetos();
    };

    render(){
        return(
            <View style={styles.overlay}>
                <View style={styles.main}>
                    <FlatList 
                        contentContainerStyle={styles.listaMain}
                        data={this.state.listaProjetos}
                        keyExtractor={item => item.idProjetoNavigation.idProjeto}
                        renderItem={this.renderItem}
                    />
                </View>
            </View>
        );
    }

    renderItem = ({item}) => (
        <View contentContainerStyle={styles.mainBodyContent}>
            <View style={styles.flatItemContainer}>
                <Text style={styles.flatItemTitle}>{item.idProjetoNavigation.projeto1}</Text>
                <Text style={styles.flatItemInfo}>{item.idTemaNavigation.tema1}</Text>
                <Text style={styles.flatItemInfo}>{item.idProjetoNavigation.idProfessorNavigation.nome}</Text>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: 'rgba(183, 39, 255, 0.79)'
    },

    main: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center'
    },

    mainBodyContent: {
        paddingTop: 30,
        paddingRight: 50,
        paddingLeft: 50
    },
      // dados do evento de cada item da lista (ou seja, cada linha da lista)
      flatItemRow: {
        flexDirection: 'row',
        borderBottomWidth: 1,
        borderBottomColor: '#ccc',
        marginTop: 30
    },
      flatItemContainer: {
        flex: 1
    },
      flatItemTitle: {
        fontSize: 16,
        color: '#333',
        fontFamily: 'Open Sans Light'
    },
      flatItemInfo: {
        fontSize: 12,
        color: '#999',
        lineHeight: 20
    },
});