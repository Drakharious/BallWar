# 🎮 BallWar - Guía Completa del Juego

## 📋 Descripción

BallWar es un emocionante juego 3D donde controlas una esfera que debe recolectar objetos mientras evita enemigos peligrosos. ¡Pon a prueba tus reflejos y habilidades para conseguir la victoria!

---

## 🎯 Objetivo del Juego

Recolecta **12 objetos (PickUps)** dispersos por el escenario para ganar la partida. Pero ten cuidado: si tocas un enemigo o caes fuera de la plataforma, ¡perderás!

---

## 🕹️ Controles

### Movimiento

- **W** o **Flecha Arriba**: Mover hacia adelante
- **S** o **Flecha Abajo**: Mover hacia atrás
- **A** o **Flecha Izquierda**: Mover hacia la izquierda
- **D** o **Flecha Derecha**: Mover hacia la derecha

### Acciones

- **Barra Espaciadora**: Saltar

---

## 🎮 Cómo Jugar

### 1. Inicio de la Partida

- Al comenzar el juego, tu esfera aparecerá en el centro de la plataforma
- Tienes **3 segundos de invencibilidad** al inicio para que puedas orientarte
- El contador en pantalla mostrará: `Count: 0`

### 2. Durante el Juego

- **Recolecta objetos**: Muévete por la plataforma y toca los objetos amarillos (PickUps) para recolectarlos
- **Evita enemigos**: Los enemigos (cubos rojos) patrullan la zona. ¡No los toques!
- **Mantente en la plataforma**: Si caes al vacío, perderás automáticamente
- **Usa el salto**: Presiona la barra espaciadora para saltar y esquivar enemigos o superar obstáculos

### 3. Contador de Progreso

- Cada vez que recojas un objeto, el contador aumentará: `Count: 1`, `Count: 2`, etc.
- Necesitas llegar a `Count: 12` para ganar

### 4. Condiciones de Victoria

✅ **GANAS** cuando recolectas los 12 objetos

- Aparecerá el mensaje: **"You Win!"**

### 5. Condiciones de Derrota

❌ **PIERDES** si:

- Tocas un enemigo (después de los 3 segundos iniciales)
- Caes fuera de la plataforma (por debajo de Y = -10)
- Aparecerá el mensaje de derrota y el juego se pausará

---

## 🎲 Mecánicas del Juego

### Física de la Esfera

- La esfera se mueve aplicando fuerzas físicas realistas
- Tiene inercia: seguirá moviéndose un poco después de soltar las teclas
- El salto aplica una fuerza hacia arriba instantánea

### Sistema de Recolección

- Los objetos desaparecen al tocarlos
- Se cuentan automáticamente en el marcador

### Enemigos

- Los enemigos patrullan el área automáticamente
- El contacto con ellos termina la partida (después de los 3 segundos iniciales)

---

## ⚙️ Requisitos del Sistema

### Para Jugar (Build)

- **Sistema Operativo**: Windows 10/11, macOS, o Linux
- **Procesador**: Intel Core i3 o equivalente
- **Memoria RAM**: 4 GB
- **Gráficos**: Tarjeta gráfica compatible con DirectX 10
- **Espacio en Disco**: 200 MB

### Para Desarrollar (Unity Editor)

- **Unity**: Versión 2022.3 LTS o superior
- **Paquetes necesarios**:
  - Input System
  - TextMeshPro
  - Universal Render Pipeline (opcional)

---

## 🚀 Instalación y Ejecución

### Opción 1: Ejecutar el Build

1. Descarga el archivo ejecutable del juego
2. Descomprime el archivo ZIP (si aplica)
3. Ejecuta el archivo `BallWar.exe` (Windows) o equivalente
4. ¡Disfruta del juego!

### Opción 2: Abrir en Unity Editor

1. Clona o descarga este repositorio
2. Abre Unity Hub
3. Click en "Add" y selecciona la carpeta del proyecto
4. Abre el proyecto con Unity 2022.3 LTS o superior
5. Espera a que Unity importe todos los assets
6. Abre la escena principal: `Assets/Scenes/MainScene.unity`
7. Presiona el botón Play ▶️ en el editor

---

## 🎨 Elementos del Juego

### Player (Jugador)

- **Apariencia**: Esfera de color
- **Componentes**: Rigidbody, Collider, PlayerController script
- **Velocidad**: Configurable (por defecto: 20)
- **Fuerza de salto**: Configurable (por defecto: 5)

### PickUps (Objetos Recolectables)

- **Apariencia**: Cubos amarillos giratorios
- **Cantidad total**: 12
- **Tag**: "PickUp"
- **Comportamiento**: Desaparecen al ser recolectados

### Enemies (Enemigos)

- **Apariencia**: Cubos rojos
- **Tag**: "Enemy"
- **Comportamiento**: Patrullan automáticamente
- **Peligro**: Terminan la partida al contacto

### Ground (Plataforma)

- **Apariencia**: Plano grande
- **Función**: Superficie de juego
- **Límite**: Caer por debajo termina la partida

---

## 💡 Consejos y Estrategias

1. **Planifica tu ruta**: Observa dónde están los enemigos antes de moverte
2. **Usa el salto sabiamente**: El salto puede ayudarte a esquivar enemigos
3. **Controla la velocidad**: No corras sin control, podrías caerte de la plataforma
4. **Aprovecha los 3 segundos**: Usa el tiempo de invencibilidad inicial para explorar
5. **Mantén la calma**: La física de la esfera requiere práctica para dominarla

---

## 🛠️ Configuración Avanzada (Para Desarrolladores)

### Ajustar Dificultad

En el Inspector de Unity, selecciona el Player y modifica:

- **Speed**: Velocidad de movimiento (10-30 recomendado)
- **Jump Force**: Altura del salto (3-10 recomendado)

### Modificar Condiciones de Victoria

En `PlayerController.cs`, línea 76:

```csharp
if (count >= 12) // Cambia 12 por el número deseado
```

### Cambiar Tiempo de Invencibilidad

En `PlayerController.cs`, línea 27:

```csharp
Invoke("EnableLose", 3f); // Cambia 3f por los segundos deseados
```

### Ajustar Altura de Caída

En `PlayerController.cs`, línea 51:

```csharp
if (transform.position.y < -10f) // Cambia -10f por la altura deseada
```

---

## 📁 Estructura del Proyecto

```
UT4- AE1 - BallWar/
├── Assets/
│   ├── Scenes/
│   │   └── MainScene.unity
│   ├── Scripts/
│   │   ├── PlayerController.cs
│   │   ├── CameraController.cs
│   │   └── EnemyController.cs (si existe)
│   ├── Materials/
│   ├── Prefabs/
│   └── Input/
│       └── playerInputs.inputactions
├── ProjectSettings/
├── Packages/
└── README.md
```

---

## 🐛 Solución de Problemas

### El jugador no se mueve

- Verifica que el Input System esté instalado
- Asegúrate de que el Default Map esté configurado en "Player"
- Comprueba que el componente Player Input esté en el GameObject

### El salto no funciona

- Verifica que la acción "Jump" esté configurada en el Input Actions
- Asegúrate de que esté asignada a la barra espaciadora
- Comprueba que el Rigidbody no esté en modo Kinematic

### Los objetos no se recolectan

- Verifica que los PickUps tengan el tag "PickUp"
- Asegúrate de que tengan un Collider con "Is Trigger" activado
- Comprueba que el Player tenga un Rigidbody

### El juego no detecta colisiones con enemigos

- Verifica que los enemigos tengan el tag "Enemy"
- Asegúrate de que tengan un Collider con "Is Trigger" activado
- Espera los 3 segundos de invencibilidad inicial

---

## ⭐ Aspectos Destacables de Unity

### Sistema de Input Moderno
- Implementación del **New Input System** de Unity en lugar del sistema legacy
- Uso de Input Actions Asset para mapeo flexible de controles
- Soporte para múltiples dispositivos (teclado, gamepad) sin cambios en el código
- Método basado en eventos (OnMove, OnJump) para mejor rendimiento

### Física Realista
- Uso de **Rigidbody** con física 3D completa
- Aplicación de fuerzas con **ForceMode.Impulse** para saltos naturales
- Sistema de colisiones con **Triggers** para detección de objetos y enemigos
- Física continua en **FixedUpdate** para movimiento consistente independiente del framerate

### Sistema de UI con TextMeshPro
- Integración de **TextMeshPro** para textos de alta calidad
- UI dinámica que responde a eventos del juego
- Actualización en tiempo real del contador de objetos recolectados
- Gestión de estados de UI (victoria, derrota)

### Gestión de Estados del Juego
- Sistema de invencibilidad temporal usando **Invoke**
- Control del flujo del juego con **Time.timeScale** para pausas
- Detección de límites del mundo para game over automático
- Condiciones de victoria y derrota bien definidas

### Sistema de Tags y Colisiones
- Uso eficiente de **Tags** para identificar objetos (PickUp, Enemy)
- Método **OnTriggerEnter** para detección de colisiones sin física
- Separación lógica entre diferentes tipos de colisiones

### Arquitectura de Código
- Separación de responsabilidades: PlayerController y CameraController
- Uso de variables públicas para configuración en el Inspector
- Código modular y fácilmente extensible
- Comentarios en español para mejor comprensión

### Sistema de Cámara
- Cámara que sigue al jugador con **offset constante**
- Actualización suave en cada frame
- Mantiene la perspectiva del juego de forma consistente

---

## 📝 Créditos

**Desarrollador**: Adrian Martin Velarde
**Motor**: Unity 2022.3 LTS  
**Lenguaje**: C#  
**Paquetes Utilizados**: Input System, TextMeshPro

---

## 📄 Licencia

Este proyecto es de uso educativo.

---

## 🎉 ¡Diviértete Jugando!

¿Conseguirás recolectar los 12 objetos sin caer o tocar enemigos? ¡Acepta el desafío de BallWar!

---

**Versión**: 1.0  
**Última actualización**: 2024
