import React, {Component} from 'react';
import {Link} from "react-router-dom";

export default class CharacterNav extends Component {
    render() {
        return (
            <>
                <nav className="navbar navbar-expand-lg">
                        <Link to="/"><h1 className="navbar-brand">Electric Games</h1></Link>
                    <ul className="navbar-nav">
                        <Link className="nav-link" to="/CharactersCollection/ShowAllCharacters">Show all characters</Link>
                        <Link className="nav-link" to="/CharactersCollection/GetCharacterById">Search characters by ID</Link>
                        <Link className="nav-link" to="/CharactersCollection/GetCharacterByName">Search characters by name</Link>
                        <Link className="nav-link" to="/CharactersCollection/AddNewCharacter">Add new character</Link>
                        <Link className="nav-link" to="/CharactersCollection/UpdateCharacter">Update character</Link>
                        <Link className="nav-link" to="/CharactersCollection/DeleteCharacter">Delete character</Link>
                    </ul>
                </nav>
                <div>
                    <h4 className="pagesection">Character Collection</h4>
                </div>
            </>
        )
    }
}